using IF4101_ProyectoFinal.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IF4101_ProyectoFinal.Views
{
    public partial class LoadPlateView : System.Web.UI.Page
    {

        A_ADD_PLATE DAPlate = new A_ADD_PLATE();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void loadDetails(int id)
        {
            LoadPlateControl imagen = DAPlate.getPlate(id);
            plateName.Text = imagen.PlateName1;
            plateDescription.Text = imagen.PlateDescription1;
            imagePlate.ImageUrl = imagen.ImageURL1;
        }

        private byte[] getImage()
        {
            String[] ExtentImage = { "jpg", "gif", "png", "jpeg", "bmp", "jfif" };
            if (!FUImage.HasFile)
            {
                throw new Exception("Debe seleccionar una imagen para la tela");
            }
            else
            {
                Bitmap imageOriginal = new Bitmap(FUImage.PostedFile.InputStream);
                System.Drawing.Image newImage = resizeImage(imageOriginal, 200);
                byte[] image = new byte[200];
                ImageConverter imageConverter = new ImageConverter();
                image = (byte[])imageConverter.ConvertTo(newImage, typeof(byte[]));
                return image;
            }

            throw new Exception("Debe ingresar un formato válido de imagen");
        }

        private System.Drawing.Image resizeImage(System.Drawing.Image image, int height)
        {
            var radio = (double)height / image.Height;
            var newHeight = (int)(image.Height * radio);
            var newWidth = (int)(image.Width * radio);
            var newImage = new Bitmap(newWidth, newHeight);
            var graphics = Graphics.FromImage(newImage);
            graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            LoadPlateControl plate = new LoadPlateControl();
            plate.PlatePhoto1 = getImage();
            plate.PlateName1 = plateName.Text;
            plate.PlateDescription1 = plateDescription.Text;

            if (plateStatus.SelectedValue == "Sí")
            {
                plate.PlateStatus1 = true;
            }
            else if (plateStatus.SelectedValue == "No")
            {
                plate.PlateStatus1 = false;
            }

            DAPlate.addPlate(plate);
        }
    }
}