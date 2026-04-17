using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace FileCompare
{
    
    public partial class Form1 : Form
    {
        // 1. 폴더 통째로 복사하는 함수 (이게 없어서 에러 났던 거여!)
        private void CopyDirectory(string sourceDir, string destDir)
        {
            if (!Directory.Exists(destDir)) Directory.CreateDirectory(destDir);

            // 파일 복사
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destDir, Path.GetFileName(file));
                CopyFileWithSafetyCheck(file, destFile);
            }
            // 하위 폴더 복사 (재귀)
            foreach (string subDir in Directory.GetDirectories(sourceDir))
            {
                string destSubDir = Path.Combine(destDir, Path.GetFileName(subDir));
                CopyDirectory(subDir, destSubDir);
            }
        }

        // 2. 파일 하나를 날짜 비교해서 안전하게 복사하는 함수 (중복된 거 다 지우고 이거 하나만 쓰쇼!)
        private void CopyFileWithSafetyCheck(string sourcePath, string destPath)
        {
            if (File.Exists(destPath))
            {
                FileInfo src = new FileInfo(sourcePath);
                FileInfo dst = new FileInfo(destPath);

                // 이미지 요청대로 날짜 정보 포함!
                if (src.LastWriteTime < dst.LastWriteTime)
                {
                    string msg = $"대상에 동일한 이름의 파일이 이미 있습니다.\n" +
                                 $"대상 파일이 더 신규 파일입니다. 덮어쓰시겠습니까?\n\n" +
                                 $"원본: {src.LastWriteTime:yyyy-MM-dd HH:mm:ss}\n{sourcePath}\n" +
                                 $"대상: {dst.LastWriteTime:yyyy-MM-dd HH:mm:ss}\n{destPath}";

                    if (MessageBox.Show(msg, "덮어쓰기 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }
            }
            File.Copy(sourcePath, destPath, true);
        }
        private void CompareAndPopulate()
        {
            // 우리가 쓰던 텍스트박스 이름으로 복구!
            string leftPath = txtPathLeft.Text;
            string rightPath = txtPathRight.Text;

            // 1. 양쪽 경로가 모두 입력되었고 존재하는지 확인
            if (string.IsNullOrWhiteSpace(leftPath) || !Directory.Exists(leftPath) ||
                string.IsNullOrWhiteSpace(rightPath) || !Directory.Exists(rightPath))
            {
                return;
            }

            // 화면 깜빡임 방지 (우리가 쓰던 리스트뷰 이름으로 복구!)
            lvFilesLeft.BeginUpdate();
            lvFilesRight.BeginUpdate();
            lvFilesLeft.Items.Clear();
            lvFilesRight.Items.Clear();

            try
            {
                // 2. 파일 목록 가져오기 및 정렬 (PPT의 고급 LINQ 적용)
                var leftFiles = Directory.EnumerateFiles(leftPath)
                                         .Select(p => new FileInfo(p))
                                         .OrderBy(f => f.Name).ToList();

                var rightFiles = Directory.EnumerateFiles(rightPath)
                                          .Select(p => new FileInfo(p))
                                          .OrderBy(f => f.Name).ToList();

                // --- [왼쪽 리스트뷰(lvFilesLeft) 채우기 및 비교] ---
                foreach (var lf in leftFiles)
                {
                    var litem = new ListViewItem(lf.Name);
                    litem.UseItemStyleForSubItems = true; // 행 전체 색상 적용 (필수)
                    litem.SubItems.Add((lf.Length / 1024).ToString("N0") + " KB");
                    litem.SubItems.Add(lf.LastWriteTime.ToString("g")); // PPT 날짜 형식 ("g")

                    // 오른쪽 파일 중 이름이 같은 파일 찾기 (대소문자 무시)
                    var rf = rightFiles.FirstOrDefault(f => f.Name.Equals(lf.Name, StringComparison.OrdinalIgnoreCase));

                    if (rf == null)
                    {
                        litem.ForeColor = Color.Purple; // 단독 파일
                    }
                    else
                    {
                        if (lf.LastWriteTime > rf.LastWriteTime) litem.ForeColor = Color.Red;      // New
                        else if (lf.LastWriteTime < rf.LastWriteTime) litem.ForeColor = Color.Gray; // Old
                        else litem.ForeColor = Color.Black;                                         // 동일
                    }
                    lvFilesLeft.Items.Add(litem); // 원래 이름
                }

                // --- [오른쪽 리스트뷰(lvFilesRight) 채우기 및 비교] ---
                foreach (var rf in rightFiles)
                {
                    var ritem = new ListViewItem(rf.Name);
                    ritem.UseItemStyleForSubItems = true; // 행 전체 색상 적용 (필수)
                    ritem.SubItems.Add((rf.Length / 1024).ToString("N0") + " KB");
                    ritem.SubItems.Add(rf.LastWriteTime.ToString("g"));

                    // 왼쪽 파일 중 이름이 같은 파일 찾기
                    var lf = leftFiles.FirstOrDefault(f => f.Name.Equals(rf.Name, StringComparison.OrdinalIgnoreCase));

                    if (lf == null)
                    {
                        ritem.ForeColor = Color.Purple; // 단독 파일
                    }
                    else
                    {
                        // 오른쪽 파일(rf) 기준으로 비교!
                        if (rf.LastWriteTime > lf.LastWriteTime) ritem.ForeColor = Color.Red;      // New
                        else if (rf.LastWriteTime < lf.LastWriteTime) ritem.ForeColor = Color.Gray; // Old
                        else ritem.ForeColor = Color.Black;                                         // 동일
                    }
                    lvFilesRight.Items.Add(ritem); // 원래 이름
                }

                // 3. 컬럼 너비 자동 조정 (우리가 쓰던 리스트뷰 이름 적용)
                for (int i = 0; i < lvFilesLeft.Columns.Count; i++)
                    lvFilesLeft.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);

                for (int i = 0; i < lvFilesRight.Columns.Count; i++)
                    lvFilesRight.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            catch (DirectoryNotFoundException) // PPT 예외 처리
            {
                MessageBox.Show(this, "폴더를 찾을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show(this, "입출력 오류: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 반드시 잠금 해제
                lvFilesLeft.EndUpdate();
                lvFilesRight.EndUpdate();
            }
        }

        // ⭐ 색상을 결정해서 리스트뷰 아이템을 만들어주는 전용 함수
        private ListViewItem CreateColoredItem(FileInfo myFile, FileInfo targetFile)
        {
            ListViewItem item = new ListViewItem(myFile.Name);
            item.SubItems.Add((myFile.Length / 1024).ToString("N0") + " KB");
            item.SubItems.Add(myFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));

            // 이 설정이 'true'여야 행 전체에 색깔이 나옵니다!
            item.UseItemStyleForSubItems = true;

            if (targetFile == null)
            {
                item.ForeColor = Color.Purple; // 반대편에 없는 '단독 파일'
            }
            else
            {
                // 날짜 비교 (수정 후: Red / 수정 전: Gray)
                if (myFile.LastWriteTime > targetFile.LastWriteTime)
                {
                    item.ForeColor = Color.Red;   // 내가 더 최신 (수정 후)
                }
                else if (myFile.LastWriteTime < targetFile.LastWriteTime)
                {
                    item.ForeColor = Color.Gray;  // 내가 더 과거 (수정 전)
                }
                else
                {
                    item.ForeColor = Color.Black; // 동일 파일
                }
            }
            return item;
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
                // 여기서 창을 딱 한 번만 띄웁니다.
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    // 텍스트박스에 폴더 경로를 쓰고
                    txtPathRight.Text = fbd.SelectedPath;

                    // 최종으로 완성한 양쪽 비교 및 색칠 함수를 실행합니다.
                    CompareAndPopulate();
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
                string sourcePath = Path.Combine(txtPathLeft.Text, item.Text);
                string destPath = Path.Combine(txtPathRight.Text, item.Text);

                if (Directory.Exists(sourcePath)) CopyDirectory(sourcePath, destPath);
                else if (File.Exists(sourcePath)) CopyFileWithSafetyCheck(sourcePath, destPath);
            }
            CompareAndPopulate(); // 화면 갱신
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
                // 여기서 창을 딱 한 번만 띄웁니다.
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    // 텍스트박스에 폴더 경로를 쓰고
                    txtPathLeft.Text = fbd.SelectedPath;

                    // 최종으로 완성한 양쪽 비교 및 색칠 함수를 실행합니다.
                    CompareAndPopulate();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lvFilesLeft.SelectedItems.Count == 0) return;

            try
            {
                foreach (ListViewItem item in lvFilesLeft.SelectedItems)
                {
                    string fileName = item.Text;
                    string sourceFile = Path.Combine(txtPathLeft.Text, fileName);
                    string destFile = Path.Combine(txtPathRight.Text, fileName);

                    if (Directory.Exists(sourceFile))
                    {
                       
                    }
                    else if (File.Exists(sourceFile))
                    {
                       
                    }
                }

                // 2. 메시지 창 대신, 화면(리스트뷰 색상)만 즉시 업데이트!
                // 사용자는 색깔이 검은색으로 변하는 걸 보고 "아, 복사 됐구나" 알 수 있습니다.
                CompareAndPopulate();
            }
            catch (Exception)
            {
                // 정말 심각한 에러가 아니면 조용히 처리하거나, 
                // 필요하다면 최소한의 에러 내용만 남겨둡니다.
            }
        }
        // ⭐ 파일 하나를 안전하게 복사하는 기계
       
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

        private void lvFilesLeft_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }

}
