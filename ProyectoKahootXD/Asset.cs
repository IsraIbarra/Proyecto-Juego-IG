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
            string proyectoRaiz = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
            string ruta = Path.Combine(proyectoRaiz, "Recursos", "Imagenes", nombreArch);

            if (!File.Exists(ruta))
            {
                proyectoRaiz = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
                ruta = Path.Combine(proyectoRaiz, "Recursos", "Imagenes", nombreArch);
            }

            if (!File.Exists(ruta))
            {
                MessageBox.Show("¡No encuentro la imagen!\n\nLa busqué aquí:\n" + ruta +
                                "\n\nRevisa que la carpeta 'Recursos' esté en ese lugar.", "Error de Ruta");
                return null;
            }

            return Image.FromFile(ruta);
        }

        public string soundLoader(string nombreArch)
        {
            string ruta = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\Recursos\Audios",
                nombreArch
            );

            return Path.GetFullPath(ruta);
        }
    }
}
