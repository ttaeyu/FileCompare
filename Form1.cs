using System.IO;
using System.Drawing;

namespace FileCompare
{
    public partial class Form1 : Form
    {
        private void CopyFileWithConfirmation(string srcPath, string destPath)
        {
            // 1. 만약 목적지에 이미 파일이 있당가?
            if (File.Exists(destPath))
            {
                FileInfo srcInfo = new FileInfo(srcPath);
                FileInfo destInfo = new FileInfo(destPath);

                // 2. [핵심!] 오래된 파일(src)로 새로운 파일(dest)을 덮어쓰려고 하냐잉?
                if (srcInfo.LastWriteTime < destInfo.LastWriteTime)
                {
                    var result = MessageBox.Show(
                        $"{srcInfo.Name} 파일은 대상 폴더의 파일보다 오래된 것이여!\n진짜로 덮어씌워버릴 거여?",
                        "날짜 확인!",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    // 사용자가 "아따, 싫쇼!" 하면 취소해부러!
                    if (result == DialogResult.No) return;
                }
            }

            // 3. 파일 복사 실행! (true는 덮어쓰기 허용이라는 뜻이여)
            File.Copy(srcPath, destPath, true);
        }
        private void CompareAndPopulate()
        {
            // 0. 준비물: 양쪽 경로가 다 있어야 비교를 하것제?
            string leftPath = txtPathLeft.Text;
            string rightPath = txtPathRight.Text;

            if (!Directory.Exists(leftPath) || !Directory.Exists(rightPath)) return;

            // 1. 일단 양쪽 리스트뷰 싹 비우고 시작하쇼!
            lvFilesLeft.Items.Clear();
            lvFilesRight.Items.Clear();

            // 2. 양쪽 폴더의 파일 목록을 싹 긁어오기
            DirectoryInfo leftDir = new DirectoryInfo(leftPath);
            DirectoryInfo rightDir = new DirectoryInfo(rightPath);

            FileInfo[] leftFiles = leftDir.GetFiles();
            FileInfo[] rightFiles = rightDir.GetFiles();

            // --- [왼쪽 리스트뷰 채우면서 비교하기] ---
            foreach (var lFile in leftFiles)
            {
                ListViewItem item = new ListViewItem(lFile.Name);
                item.SubItems.Add((lFile.Length / 1024).ToString("N0") + " KB");
                item.SubItems.Add(lFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));

                // 오른쪽 폴더에 똑같은 이름의 파일이 있는지 찾아부러!
                FileInfo rFile = Array.Find(rightFiles, f => f.Name == lFile.Name);

                if (rFile == null)
                {
                    // [3단계: 단독 파일] - 보라색!
                    item.ForeColor = Color.Purple;
                }
                else
                {
                    // [1단계: 비교 기준] - 수정시간 비교 들어가야제!
                    if (lFile.LastWriteTime > rFile.LastWriteTime)
                    {
                        // [2단계: New] - 내가 더 최신이면 빨간색!
                        item.ForeColor = Color.Red;
                    }
                    else if (lFile.LastWriteTime < rFile.LastWriteTime)
                    {
                        // [2단계: Old] - 내가 더 옛날이면 회색!
                        item.ForeColor = Color.Gray;
                    }
                    else
                    {
                        // [2단계: 동일] - 검은색!
                        item.ForeColor = Color.Black;
                    }
                }
                lvFilesLeft.Items.Add(item);
            }

            // --- [오른쪽 리스트뷰 채우면서 비교하기] ---
            foreach (var rFile in rightFiles)
            {
                ListViewItem item = new ListViewItem(rFile.Name);
                item.SubItems.Add((rFile.Length / 1024).ToString("N0") + " KB");
                item.SubItems.Add(rFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));

                // 이번엔 왼쪽 폴더에 있는지 확인!
                FileInfo lFile = Array.Find(leftFiles, f => f.Name == rFile.Name);

                if (lFile == null)
                {
                    // [3단계: 단독 파일] - 보라색!
                    item.ForeColor = Color.Purple;
                }
                else
                {
                    if (rFile.LastWriteTime > lFile.LastWriteTime)
                    {
                        // [2단계: New] - 오른쪽이 더 최신이면 빨간색!
                        item.ForeColor = Color.Red;
                    }
                    else if (rFile.LastWriteTime < lFile.LastWriteTime)
                    {
                        // [2단계: Old] - 오른쪽이 더 옛날이면 회색!
                        item.ForeColor = Color.Gray;
                    }
                    else
                    {
                        item.ForeColor = Color.Black;
                    }
                }
                lvFilesRight.Items.Add(item);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void PopulateListView(string folderPath, ListView targetListView)
        {
            // 이제 lvFilesLeft 대신 'targetListView'라는 이름을 써야 만능이 된당게!
            targetListView.Items.Clear();

            try
            {
                // 폴더 훑기
                foreach (string dirPath in Directory.EnumerateDirectories(folderPath))
                {
                    DirectoryInfo di = new DirectoryInfo(dirPath);
                    ListViewItem item = new ListViewItem(di.Name);
                    item.SubItems.Add("<Folder>");
                    item.SubItems.Add(di.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    item.ForeColor = Color.Blue;
                    targetListView.Items.Add(item); // 전달받은 리스트뷰에 쏙!
                }

                // 파일 훑기
                foreach (string filePath in Directory.EnumerateFiles(folderPath))
                {
                    FileInfo fi = new FileInfo(filePath);
                    ListViewItem item = new ListViewItem(fi.Name);
                    long kbSize = fi.Length / 1024;
                    item.SubItems.Add(kbSize.ToString("N0") + " KB");
                    item.SubItems.Add(fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    targetListView.Items.Add(item); // 전달받은 리스트뷰에 쏙!
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" 에러!: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPathRight.Text = fbd.SelectedPath;
                    CompareAndPopulate(); // 아따, 인쟈 요놈만 부르면 끝이여!
                }
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    // 1. 오른쪽 경로 텍스트박스에 주소 딱 찍고!
                    txtPathRight.Text = fbd.SelectedPath;

                    // 2. ⭐ 요기가 포인트! 이번엔 'lvFilesRight'를 넣어주는 거여!
                    PopulateListView(fbd.SelectedPath, lvFilesRight);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lvFilesLeft.SelectedItems.Count == 0) return;

            foreach (ListViewItem item in lvFilesLeft.SelectedItems)
            {
                // 2. 파일 이름이랑 전체 경로를 딱 따와부러!
                string fileName = item.Text;
                string srcFullPath = Path.Combine(txtPathLeft.Text, fileName);
                string destFullPath = Path.Combine(txtPathRight.Text, fileName);

                try
                {
                    // 3. 아까 만든 안전 복사 함수 출동!
                    CopyFileWithConfirmation(srcFullPath, destFullPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"에러: {ex.Message}");
                }
            }

            // 4. 복사 다 했으믄 리스트뷰를 다시 그려야 색깔이 바뀌것제?
            CompareAndPopulate();
            MessageBox.Show("복사 완료!");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
 
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPathLeft.Text = fbd.SelectedPath;
                    CompareAndPopulate(); // 아따, 인쟈 요놈만 부르면 끝이여!
                }
                // 2. 사용자가 폴더를 고르고 '확인'을 눌렀다면?
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    // 3. 텍스트박스에 그 폴더 경로를 딱 써주고
                    txtPathLeft.Text = fbd.SelectedPath;

                    // 4. 2단계에서 만든 함수를 불러서 리스트뷰에 파일을 촤르륵 뿌려줘!
                    PopulateListView(fbd.SelectedPath, lvFilesLeft);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lvFilesRight.SelectedItems.Count == 0) return;

            foreach (ListViewItem item in lvFilesRight.SelectedItems)
            {
                // 2. 파일 이름이랑 전체 경로를 딱 따와부러!
                string fileName = item.Text;
                string srcFullPath = Path.Combine(txtPathLeft.Text, fileName);
                string destFullPath = Path.Combine(txtPathRight.Text, fileName);

                try
                {
                    // 3. 아까 만든 안전 복사 함수 출동!
                    CopyFileWithConfirmation(srcFullPath, destFullPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"에러: {ex.Message}");
                }
            }

            // 4. 복사 다 했으믄 리스트뷰를 다시 그려야 색깔이 바뀌것제?
            CompareAndPopulate();
            MessageBox.Show("복사 완료!");
        }

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void lvFilesRight_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
