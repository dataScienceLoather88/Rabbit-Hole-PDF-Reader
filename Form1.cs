using System;
using System.Drawing.Imaging;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;
using iText.Layout.Renderer;
using PdfiumViewer; // Import PdfiumViewer

using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Navigation;
using iText.Kernel.Utils;
using System.IO;

using iText.Bouncycastle;
using iText.Bouncycastleconnector;

namespace EbookReaderTest
{
    public partial class Form1 : Form
    {
        private PdfViewer pdfViewer; // Declare PdfViewer
        private PdfiumViewer.PdfSearchManager searchManager;
        private bool isDarkMode = false;
        private bool isBookmarkVisable = false;
        private string currentPdfPath;

        public Form1()
        {
            InitializeComponent(); // Keep this line
            this.Text = "Rabbit Hole";
            checkForPdfDirectory(); //ensurePdfDirectoryExists()
            showPdfSelectionDialogue();
        }

        private void checkForPdfDirectory()
        {
            string pdfFolder = Path.Combine(Application.StartupPath, "PDF Library");
            if (!Directory.Exists(pdfFolder))
            {
                Directory.CreateDirectory(pdfFolder);
            }
        }

        private void showPdfSelectionDialogue()
        {
            string filePath = Path.Combine(Application.StartupPath, "PDF Library");
            OpenFileDialog bookSelectionDialogue = new OpenFileDialog();
            bookSelectionDialogue.InitialDirectory = filePath;
            bookSelectionDialogue.Filter = "PDF Files (*.pdf)|*.pdf";
            bookSelectionDialogue.Title = "Select a PDF to load:";
            if (bookSelectionDialogue.ShowDialog() == DialogResult.OK)
            {
                LoadPDF(bookSelectionDialogue.FileName);
            }
            //else if (bookSelectionDialogue.ShowDialog() == DialogResult.Cancel)
            //{
            //    this.Close();
            //}

        }

        private void LoadPDF(string filePath, int page = 0)
        {
            if (pdfViewer == null)
            {
                pdfViewer = new PdfViewer();
                pdfViewer.Dock = DockStyle.Fill;
                pdfViewer.Renderer.MouseWheel += PdfViewer_MouseWheel;
                this.Controls.Add(pdfViewer);
            }

            try
            {
                pdfViewer.Document = PdfiumViewer.PdfDocument.Load(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading file: " + ex.Message);
                return;
            }

            currentPdfPath = filePath;

            pdfViewer.Renderer.Page = page;

            UpdatePageLabel();
            pdfViewer.ShowBookmarks = false;
            panel1.Left = this.Width - panel1.Width - 60;
            this.WindowState = FormWindowState.Maximized;
            //pdfViewer.Renderer.Page = pdfViewer.Renderer.Page + 1;
        }

        private void AddBookmarkToPdf(string bookmarkTitle, int pageIndex, string inputPath)
        {
            string tempPath = Path.GetTempFileName(); // You can change this to inputPath + "_modified.pdf" if you prefer

            using (PdfReader reader = new PdfReader(inputPath))
            using (PdfWriter writer = new PdfWriter(tempPath))
            {
                iText.Kernel.Pdf.PdfDocument pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader, writer);

                // Get the root outline (bookmark container)
                PdfOutline root = pdfDoc.GetOutlines(false);
                PdfOutline bookmark = root.AddOutline(bookmarkTitle);

                // Create a destination that jumps to the desired page (pageIndex is 0-based)
                bookmark.AddDestination(PdfExplicitDestination.CreateFit(pdfDoc.GetPage(pageIndex + 1)));

                pdfDoc.Close(); // Save and close
            }

            pdfViewer.Document?.Dispose();
            pdfViewer.Document = null;

            // Replace the original PDF with the modified one
            File.Delete(inputPath);
            File.Move(tempPath, inputPath);

            // Reload the updated PDF in PdfiumViewer
            LoadPDF(inputPath, pageIndex);
        }


        private void btnAddBookmark_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(currentPdfPath);
            if (pdfViewer?.Document == null)
                return;
            if (isDarkMode)
                return;

            // Ask user for bookmark title
            string title = Microsoft.VisualBasic.Interaction.InputBox("Enter bookmark title:", "Add Bookmark", "Bookmark");

            if (!string.IsNullOrWhiteSpace(title))
            {
                int currentPage = pdfViewer.Renderer.Page; // 0-based index
                AddBookmarkToPdf(title, currentPage, /* path to current file */ currentPdfPath);
            }
        }

        private void btnShowBookmarks_Click(object sender, EventArgs e)
        {
            if (pdfViewer?.Document == null)
                return;
            if (isDarkMode)
                return;
            isBookmarkVisable = !isBookmarkVisable;
            if (isBookmarkVisable)
                pdfViewer.ShowBookmarks = true;
            else 
                pdfViewer.ShowBookmarks = false;
            if (pdfViewer.Document.Bookmarks == null)
                pdfViewer.ShowBookmarks = false;
        }

        private void PdfViewer_MouseWheel(object sender, MouseEventArgs e)
        {
            UpdatePageLabel();
        }

        private void UpdatePageLabel()
        {
            if (pdfViewer.Document == null) return;
            int currentPage = pdfViewer.Renderer.Page + 1;
            int totalPages = pdfViewer.Document.PageCount;
            pgeInfo.Text = $"{currentPage} / {totalPages}";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (pdfViewer.Renderer.Page == 0)
                return;
            pdfViewer.Renderer.Page = pdfViewer.Renderer.Page - 1;
            UpdatePageLabel();
            if (isDarkMode)
                ShowInvertedPdfPage();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (pdfViewer.Renderer.Page == pdfViewer.Document.PageCount)
                return;
            pdfViewer.Renderer.Page = pdfViewer.Renderer.Page + 1;
            UpdatePageLabel();
            if (isDarkMode)
                ShowInvertedPdfPage();
        }

        private void btnToggleTheme_Click(object sender, EventArgs e)
        {
            if (isBookmarkVisable)
            {
                isBookmarkVisable = false;
                pdfViewer.ShowBookmarks = false;
            }

            isDarkMode = !isDarkMode;

            if (isDarkMode)
            {
                ShowInvertedPdfPage();
                pictureBoxInverted.Visible = true;
                pdfViewer.Visible = false;
                blackBg.Visible = true;

                panel1.BackColor = Color.Black;
                txtSearch.BackColor = Color.Black;
                txtSearch.ForeColor = Color.White;
                btnSearch.BackColor = Color.Black;
                btnSearch.ForeColor = Color.White;
                btnNext.BackColor = Color.Black;
                btnNext.ForeColor = Color.White;
                pgeInfo.BackColor = Color.Black;
                pgeInfo.ForeColor = Color.White;
                btnToggleTheme.BackColor = Color.Black;
                btnToggleTheme.ForeColor = Color.White;
                btnBack.BackColor = Color.Black;
                btnBack.ForeColor = Color.White;
                btnForward.BackColor = Color.Black;
                btnForward.ForeColor = Color.White;
                btnAddBookmark.BackColor = Color.Black;
                btnAddBookmark.ForeColor = Color.White;
                btnShowBookmarks.BackColor = Color.Black;
                btnShowBookmarks.ForeColor = Color.White;


            }
            else
            {
                pictureBoxInverted.Visible = false;
                pdfViewer.Visible = true;
                blackBg.Visible = false;

                panel1.BackColor = SystemColors.Control;
                txtSearch.BackColor = SystemColors.Window;
                txtSearch.ForeColor = SystemColors.ControlText;
                btnSearch.BackColor = SystemColors.ButtonHighlight;
                btnSearch.ForeColor = SystemColors.ControlText;
                btnNext.BackColor = SystemColors.ButtonHighlight;
                btnNext.ForeColor = SystemColors.ControlText;
                pgeInfo.BackColor = SystemColors.ButtonHighlight;
                pgeInfo.ForeColor = SystemColors.ControlText;
                btnToggleTheme.BackColor = SystemColors.ButtonHighlight;
                btnToggleTheme.ForeColor = SystemColors.ControlText;
                btnBack.BackColor = SystemColors.ButtonHighlight;
                btnBack.ForeColor = SystemColors.ControlText;
                btnForward.BackColor = SystemColors.ButtonHighlight;
                btnForward.ForeColor = SystemColors.ControlText;
                btnAddBookmark.BackColor = SystemColors.ButtonHighlight;
                btnAddBookmark.ForeColor = SystemColors.ControlText;
                btnShowBookmarks.BackColor = SystemColors.ButtonHighlight;
                btnShowBookmarks.ForeColor = SystemColors.ControlText;
            }
        }

        private void ShowInvertedPdfPage()
        {
            if (pdfViewer?.Document == null) return;

            int width = pdfViewer.Renderer.Width / 2;
            width = width - width / 5;

            int height = pdfViewer.Renderer.Height;


            using (var originalImage = pdfViewer.Document.Render(
                pdfViewer.Renderer.Page,
                width, height,
                96, 96,
                PdfRenderFlags.Annotations))
            {
                Bitmap original = new Bitmap(originalImage);
                Bitmap inverted = InvertBitmap(original);
                pictureBoxInverted.Image = inverted;
                pictureBoxInverted.Height = height;
                pictureBoxInverted.Width = width;
                pictureBoxInverted.Left = width / 2 + width / 4; 
            }
        }

        private Bitmap InvertBitmap(Bitmap original)
        {
            Bitmap inverted = new Bitmap(original.Width, original.Height);

            using (Graphics g = Graphics.FromImage(inverted))
            {
                ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                {
            new float[] {-1, 0, 0, 0, 0},
            new float[] {0, -1, 0, 0, 0},
            new float[] {0, 0, -1, 0, 0},
            new float[] {0, 0, 0, 1, 0},
            new float[] {1, 1, 1, 0, 1}
                });

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(original,
                    new Rectangle(0, 0, original.Width, original.Height),
                    0, 0, original.Width, original.Height,
                    GraphicsUnit.Pixel, attributes);
            }

            return inverted;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (pdfViewer?.Document == null || string.IsNullOrWhiteSpace(txtSearch.Text))
                return;
            if (isDarkMode)
                return;

            searchManager = new PdfSearchManager(pdfViewer.Renderer);
            searchManager.HighlightAllMatches = true;
            searchManager.MatchCase = false;
            searchManager.MatchWholeWord = false;

            searchManager.Search(txtSearch.Text);

            // No way to check match count directly,
            // so assume something was found and enable Find Next
            btnNext.Enabled = true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (searchManager == null)
                return;
            if (isDarkMode)
                return;

            bool found = searchManager.FindNext(true);

            if (!found)
            {
                MessageBox.Show("No more matches found.");
            }
        }
    }
}

