﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Resources;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoPastelariaDoZe_2022.DAO;
using System.Threading.Tasks;
using System.Data.Common;

namespace ProjetoPastelariaDoZe_2022
{
    internal class ClassFuncoes
    {
        public static void CampoEventoEnter(object sender, System.EventArgs e)
        {
            if (sender is TextBoxBase txt) //MaskedTextBox, TextBox
            {
                txt.BackColor = Color.LightGreen;
            }
            else if (sender is ComboBox cb)
            {
                cb.BackColor = Color.LightGreen;
            }
            else if (sender is RadioButton rb)
            {
                rb.BackColor = Color.LightGreen;
            }
            else if (sender is ButtonBase btn)
            {
                btn.BackColor = Color.CadetBlue;
            }
        }


        public static void CampoEventoLeave(object sender, System.EventArgs e)
        {
            if (sender is TextBoxBase txt)
            {
                txt.BackColor = Color.White;
            }
            else if (sender is ComboBox cb)
            {
                cb.BackColor = Color.White;
            }
            else if (sender is RadioButton rb)
            {
                rb.BackColor = SystemColors.ActiveBorder;
            }
            else if (sender is ButtonBase btn)
            {
                btn.BackColor = Color.LightGray;
            }
        }

        /// <summary>
        /// Tratar eventos de teclado, no caso tecla ENTER funcionando com TAB e tecla ESC para fechar
        /// </summary>
        /// <remarks>KeyPreview do formulário para true.</remarks>
        /// <param name="sender">Objeto que gerou o evento</param>
        /// <param name="e">Evento que foi capturado</param>
        /// <example>No construtor do formulário:
        /// this.KeyDown += new System.Windows.Forms.KeyEventHandler(ClassFuncoes.FormEventoKeyDown);
        ///</example>
        public static void FormEventoKeyDown(object sender, KeyEventArgs e)
        {
            //obtém o form onde o componente gerou o evento
            Control x = (Control)sender;
            Form form = x.FindForm();
            //verifica se foi pressionado ENTER
            if (e.KeyCode == Keys.Enter)
            {
                //Obtém ou define um valor que indica se o evento de chave deve ser passado para o controle
                //subjacente.
                //true caso o evento chave não deva ser enviado ao controle; caso contrário, false
                //com isso evitamos o som de erro toda vez que pressionamos enter em algum campo
                e.SuppressKeyPress = true;
                //SendKeys.Send("{TAB}");
                form.SelectNextControl(form.ActiveControl, !e.Shift, true, true, true);
            }
            //verifica se foi pressionado ESC
            else if (e.KeyCode == Keys.Escape)
            {

                form.Close();

            }

        }

        public static string Sha256Hash(string senha)
        {
            // Create a new Stringbuilder to collect the bytes and create a string.
            var hash = new StringBuilder();
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));
                // Loop through each byte of the hashed data and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    hash.Append(data[i].ToString("x2"));
                }
            }
            // retorna o hash SHA256.
            return hash.ToString();
          
        }
        public static byte[] ConverteImagemParaByteArray(Image img)
        {
            MemoryStream ms = new();
            if (img != null)
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return ms.ToArray();
        }

        public static Image? ConverteByteArrayParaImagem(byte[] pData)
        {
            try
            {
                ImageConverter imgConverter = new();
                return imgConverter.ConvertFrom(pData) as Image;
            }
            catch
            {
                return null;
            }
        }
    }
}
