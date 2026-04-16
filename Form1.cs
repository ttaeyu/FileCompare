using System.IO;
namespace FileCompare
{
    public partial class Form1 : Form
    {
        private void FillListView(string folderPath, ListView targetListView)
        {
            // 1. 혹시 리스트뷰에 예전 데이터가 남아있으면 싹 지워주기 (청소!)
            targetListView.Items.Clear();

            // 2. 만약 폴더 경로가 비어있거나 없는 폴더라면 그냥 돌아가기 (예외 처리)
            if (!Directory.Exists(folderPath)) return;

            // 3. 폴더 정보를 가져오기
            DirectoryInfo di = new DirectoryInfo(folderPath);

            // 4. 폴더 안의 모든 파일을 하나씩 꺼내서 반복하기
            foreach (FileInfo file in di.GetFiles())
            {
                // [이름] 컬럼에 들어갈 아이템 만들기
                ListViewItem lvi = new ListViewItem(file.Name);

                // [크기] 컬럼에 들어갈 서브 아이템 추가 (Byte를 KB 단위로 변환)
                long kbSize = file.Length / 1024;
                lvi.SubItems.Add(kbSize.ToString("N0") + " KB");

                // [수정일] 컬럼에 들어갈 서브 아이템 추가
                lvi.SubItems.Add(file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));

                // 5. 완성된 줄(Item)을 리스트뷰에 딱! 붙여넣기
                targetListView.Items.Add(lvi);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

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

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }
    }
}
