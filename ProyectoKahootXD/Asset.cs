using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoKahootXD
{
    public class Asset
    {
        public Image imagenLoader(string nombreArch)
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"..\..\..\Recursos\Imagenes\",nombreArch);
            return Image.FromFile(ruta);
        }

        public string soundLoader(string nombreArch)
        {
            string ruta = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\..\Recursos\Audios",
                nombreArch
            );

            return Path.GetFullPath(ruta);
        }
    }
}
