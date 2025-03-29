using System;
using System.Windows.Forms;
using PdfiumViewer; // Import PdfiumViewer

namespace EbookReaderTest
{
    public partial class Form1 : Form
    {
        private PdfViewer pdfViewer; // Declare PdfViewer

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
            if(bookSelectionDialogue.ShowDialog() == DialogResult.OK)
            {
                LoadPDF(bookSelectionDialogue.FileName);
            }
            //else if (bookSelectionDialogue.ShowDialog() == DialogResult.Cancel)
            //{
            //    this.Close();
            //}

        }

        private void LoadPDF(string filePath)
        {
            if (pdfViewer == null)
            {
                pdfViewer = new PdfViewer();
                pdfViewer.Dock = DockStyle.Fill;
                this.Controls.Add(pdfViewer);
            }

            try
            {
                pdfViewer.Document = PdfDocument.Load(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading file: " + ex.Message);
            }

        }
    }
}




//pdfViewer = new PdfViewer()
//{
//    Dock = DockStyle.Fill // Make it fill the form
//};
//this.Controls.Add(pdfViewer); // Add it to the form

//try
//{
//    //pdfViewer.LoadPdf("test.pdf"); // Load a test PDF
//    pdfViewer.Document = PdfDocument.Load("test.pdf");
//}
//catch (Exception ex)
//{
//    MessageBox.Show("Error loading PDF: " + ex.Message);
//    //MessageBox.Show(Application.StartupPath);
//}


//namespace EbookReaderTest
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }
//    }
//}
