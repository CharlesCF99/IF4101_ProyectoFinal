using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IF4101_ProyectoFinal.Controls
{
    public class LoadPlateControl
    {
        private int PlateID;
        private string PlateName;
        private string PlateDescription;
        private int PlatePrice;
        private byte[] PlatePhoto;
        private bool PlateStatus;
        private string ImageURL;

        public LoadPlateControl()
        {

        }

        public LoadPlateControl(int plateID, string plateName, string plateDescription, int platePrice, byte[] platePhoto, bool plateStatus)
        {
            PlateID = plateID;
            PlateName = plateName;
            PlateDescription = plateDescription;
            PlatePrice = platePrice;
            PlatePhoto = platePhoto;
            PlateStatus = plateStatus;
        }

        public void setImageAndURL(byte[] image)
        {
            this.PlatePhoto = image;
            this.ImageURL = "data:image;base64," + Convert.ToBase64String(image);
        }

        public byte[] getImage()
        {
            return PlatePhoto;
        }

        public int PlateID1 { get => PlateID; set => PlateID = value; }
        public string PlateName1 { get => PlateName; set => PlateName = value; }
        public string PlateDescription1 { get => PlateDescription; set => PlateDescription = value; }
        public int PlatePrice1 { get => PlatePrice; set => PlatePrice = value; }
        public byte[] PlatePhoto1 { get => PlatePhoto; set => PlatePhoto = value; }
        public bool PlateStatus1 { get => PlateStatus; set => PlateStatus = value; }
        public string ImageURL1 { get => ImageURL; set => ImageURL = value; }
    }
}