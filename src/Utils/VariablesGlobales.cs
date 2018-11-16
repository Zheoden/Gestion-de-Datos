using System.Text;
using System.Security.Cryptography;
using System;
using PalcoNet.Objetos;
namespace PalcoNet.Utils {

    public class VariablesGlobales {

        public static Usuario usuario { get; set; }
        public static DateTime FechaHoraSistema = DateTime.ParseExact(Properties.Settings.Default.fechaSistema, Properties.Settings.Default.formatoFecha, null);
        public static string FechaHoraSistemaString = Properties.Settings.Default.fechaSistema;
    }
}