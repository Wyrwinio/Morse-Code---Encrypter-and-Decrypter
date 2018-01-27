using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mors_okienkowy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NAudio.Wave.WaveIn sourceStream = null;
        NAudio.Wave.DirectSoundOut waveOut = null;
        NAudio.Wave.WaveFileWriter waveWriter = null;
        private async void tlumaczenienamorsa(object sender, EventArgs e)
        {
            textBox2.Text = null;
            char[] tablica = null;
            String input = textBox1.Text;
            input = input.ToUpper();
            Dictionary<char, String> morse = new Dictionary<char, String>()
            {
                {'A' , ".-"},
                {'Ą' , ".-.-"},
                {'B' , "-..."},
                {'C' , "-.-."},
                {'Ć' , "-.-.."},
                {'D' , "-.."},
                {'E' , "."},
                {'Ę' , "..-.."},
                {'F' , "..-."},
                {'G' , "--."},
                {'H' , "...."},
                {'I' , ".."},
                {'J' , ".---"},
                {'K' , "-.-"},
                {'L' , ".-.."},
                {'Ł' , ".-..-"},
                {'M' , "--"},
                {'N' , "-."},
                {'Ń' , "--.--"},
                {'O' , "---"},
                {'Ó' , "---."},
                {'P' , ".--."},
                {'Q' , "--.-"},
                {'R' , ".-."},
                {'S' , "..."},
                {'Ś' , "...-..."},
                {'T' , "-"},
                {'U' , "..-"},
                {'V' , "...-"},
                {'W' , ".--"},
                {'X' , "-..-"},
                {'Y' , "-.--"},
                {'Z' , "--.."},
                {'Ż' , "--..-."},
                {'Ź' , "--..-"},
                {'0' , "-----"},
                {'1' , ".----"},
                {'2' , "..---"},
                {'3' , "...--"},
                {'4' , "....-"},
                {'5' , "....."},
                {'6' , "-...."},
                {'7' , "--..."},
                {'8' , "---.."},
                {'9' , "----."},

            };

            for (int i = 0; i < input.Length; i++)
            {

                if (i > 0)
                {
                    textBox2.Text += "/";
                    await Task.Delay(2000);                  
                }
                if (input[i] == ' ')
                {
                    await Task.Delay(5000);
                }
                else
                {
                    char c = input[i];
                    if (morse.ContainsKey(c))
                        textBox2.Text += morse[c];
                    tablica = morse[c].ToCharArray();                  
                    for (int i2 = 0; i2 < tablica.Length; i2++)
                    {
                        if (tablica[i2] == '.')
                        {

                            Action beep = () => Console.Beep(1000, 600); await Task.Delay(2000); beep.BeginInvoke(null, null);                           

                        }
                        if (tablica[i2] == '-')
                        {

                            Action beep2 = () => Console.Beep(1000, 1000); await Task.Delay(2000); beep2.BeginInvoke(null, null);                      
                        }
                    }


                }
            }
        }

        private async void tlumaczenienamorsapluszapis(object sender, EventArgs e)
        {
            textBox2.Text = null;
            if (sourceList.SelectedItems.Count == 0)
            {            
                MessageBox.Show("Wybierz źródło nagrywania"); }
            else {              

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Wave File (*.wav)|*.wav;";
            if (save.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            int deviceNumber = sourceList.SelectedItems[0].Index;

            sourceStream = new NAudio.Wave.WaveIn();
            sourceStream.DeviceNumber = deviceNumber;
            sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);
            sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(sourceStream_DataAvailable);
            waveWriter = new NAudio.Wave.WaveFileWriter(save.FileName, sourceStream.WaveFormat);
            sourceStream.StartRecording();
            char[] tablica = null;
            String input = textBox1.Text;
            input = input.ToUpper();
            Dictionary<char, String> morse = new Dictionary<char, String>()
            {
                {'A' , ".-"},
                {'Ą' , ".-.-"},
                {'B' , "-..."},
                {'C' , "-.-."},
                {'Ć' , "-.-.."},
                {'D' , "-.."},
                {'E' , "."},
                {'Ę' , "..-.."},
                {'F' , "..-."},
                {'G' , "--."},
                {'H' , "...."},
                {'I' , ".."},
                {'J' , ".---"},
                {'K' , "-.-"},
                {'L' , ".-.."},
                {'Ł' , ".-..-"},
                {'M' , "--"},
                {'N' , "-."},
                {'Ń' , "--.--"},
                {'O' , "---"},
                {'Ó' , "---."},
                {'P' , ".--."},
                {'Q' , "--.-"},
                {'R' , ".-."},
                {'S' , "..."},
                {'Ś' , "...-..."},
                {'T' , "-"},
                {'U' , "..-"},
                {'V' , "...-"},
                {'W' , ".--"},
                {'X' , "-..-"},
                {'Y' , "-.--"},
                {'Z' , "--.."},
                {'Ż' , "--..-."},
                {'Ź' , "--..-"},
                {'0' , "-----"},
                {'1' , ".----"},
                {'2' , "..---"},
                {'3' , "...--"},
                {'4' , "....-"},
                {'5' , "....."},
                {'6' , "-...."},
                {'7' , "--..."},
                {'8' , "---.."},
                {'9' , "----."},
            };
            for (int i = 0; i < input.Length; i++)
            {

                if (i > 0)
                {
                    textBox2.Text += "/";
                    await Task.Delay(2000);
                
                }
                if (input[i] == ' ')
                {
                    await Task.Delay(5000);
                }
                else
                {
                    char c = input[i];
                    if (morse.ContainsKey(c))
                        textBox2.Text += morse[c];
                    tablica = morse[c].ToCharArray();


                    
                    for (int i2 = 0; i2 < tablica.Length; i2++)
                    {
                        if (tablica[i2] == '.')
                        {

                           
                            Action beep = () => Console.Beep(1000, 600); await Task.Delay(2000); beep.BeginInvoke(null, null);
                            
                          


                        }
                        if (tablica[i2] == '-')
                        {

                            Action beep2 = () => Console.Beep(1000, 1000); await Task.Delay(2000); beep2.BeginInvoke(null, null);
                            

                           
                        }
                    }


                }
            }



            if (waveOut != null)
            {
                await Task.Delay(1000);
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }
            if (sourceStream != null)
            {
                await Task.Delay(1000);
                sourceStream.StopRecording();
                sourceStream.Dispose();
                sourceStream = null;
            }
            if (waveWriter != null)
            {
                await Task.Delay(1000);
                waveWriter.Dispose();
                waveWriter = null;
            }

         

        }
        }
        private void sourceStream_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            if (waveWriter == null) return;

            waveWriter.WriteData(e.Buffer, 0, e.BytesRecorded);
            waveWriter.Flush();
        }

        private void OdswiezZrodla(object sender, EventArgs e)
        {
            
                List<NAudio.Wave.WaveInCapabilities> sources = new List<NAudio.Wave.WaveInCapabilities>();

                for (int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
                {
                    sources.Add(NAudio.Wave.WaveIn.GetCapabilities(i));
                }

                sourceList.Items.Clear();

                foreach (var source in sources)
                {
                    ListViewItem item = new ListViewItem(source.ProductName);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, source.Channels.ToString()));
                    sourceList.Items.Add(item);
                }
            
        }     
              
        private NAudio.Wave.WaveFileReader wave = null;
        private NAudio.Wave.DirectSoundOut output = null;
        private void button6_Click(object sender, EventArgs e)
        
            {
            textBox2.Text = null;
            Dictionary<String, char> morse2 = new Dictionary<String, char>()
            {
                {".-" , 'A'},
                {".-.-" ,'Ą'},
                {"-...", 'B'},
                {"-.-.",'C' },
                {"-.-..",'Ć'},
                {"-.." , 'D'},
                {"." , 'E'},
                {"..-.." , 'Ę'},
                {"..-." , 'F'},
                { "--.", 'G'},
                { "....", 'H'},
                {".." , 'I'},
                {".---" , 'J'},
                {"-.-" , 'K'},
                {".-.." , 'L'},
                { ".-..-", 'Ł'},
                { "--", 'M'},
                {"-." ,'N' },
                { "--.--", 'Ń'},
                { "---", 'O'},
                {"---." , 'Ó'},
                { ".--.", 'P'},
                { "--.-", 'Q'},
                { ".-.", 'R'},
                { "...", 'S'},
                { "...-...", 'Ś'},
                { "-", 'T'},
                { "..-", 'U'},
                {"...-" , 'V'},
                {".--" ,'W' },
                { "-..-", 'X'},
                { "-.--", 'Y'},
                {"--.." , 'Z'},
                { "--..-.", 'Ż'},
                {"--..-" , 'Ź'},
                { "-----", '0'},
                {".----" ,'1' },
                {"..---" , '2'},
                { "...--", '3'},
                {"....-" , '4'},
                {"....." ,'5' },
                {"-...." , '6'},
                { "--...", '7'},
                {"---.." , '8'},
                {"----." , '9'},

            };
            OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Wave File (*.wav)|*.wav;";
                if (open.ShowDialog() != DialogResult.OK) return;
                DisposeWave();
                wave = new NAudio.Wave.WaveFileReader(open.FileName);
            customWaveViewer1.WaveStream = new NAudio.Wave.WaveFileReader(open.FileName);
            AudioFileReader readertest = new AudioFileReader(open.FileName);
            customWaveViewer1.Visible = true;
            label4.Visible = true;
            int bytesnumber = (int)readertest.Length;
            var buffer = new float[bytesnumber];
            readertest.Read(buffer, 0, bytesnumber);
            String xxx = null;
            String odszyfrowane = null;
            int i = 0;
            int poczatekbipa = 0;
            int koniecbipa = 0;
            while (i < buffer.Length - 1)
            {
                while (buffer[i] < 0.2 && buffer[i] > -0.2 && i< buffer.Length - 1) 
                {
                    i++;
                }            
            poczatekbipa = i;
                while (buffer[i] != 0 && i< buffer.Length - 1) 
                {
                    i++;
                }
                if(poczatekbipa - koniecbipa > 176500 && poczatekbipa - koniecbipa < 530000 && koniecbipa != 0){
                    odszyfrowane = odszyfrowane + '/';                    
                }
                if (poczatekbipa - koniecbipa > 530000)
                {
                    odszyfrowane = odszyfrowane + "//";
                }
            
            koniecbipa = i;
                if(koniecbipa - poczatekbipa > 21180)
                {
                    Console.WriteLine("Poczatek: " + poczatekbipa + " Koniec:" + koniecbipa);
                    int dlugoscbipa = koniecbipa - poczatekbipa;
                    Console.WriteLine("Długość bipa w probkach= " + dlugoscbipa);
                    int dlugoscbipawsek = dlugoscbipa / 353;
                    Console.WriteLine("Długość bipa w sekundach= " + dlugoscbipawsek);
                    if (dlugoscbipawsek < 130)
                    {
                        Console.WriteLine("Bip krótki ");
                        odszyfrowane = odszyfrowane + '.';
                    }
                    else
                    {
                        Console.WriteLine("Bip długi");
                        odszyfrowane = odszyfrowane + '-';
                    }
                }
            }
            Console.Write("Odszyfrowana zawartosc to: " + odszyfrowane);
            char[] tablica2 = null;
            tablica2 = odszyfrowane.ToCharArray();
            Console.WriteLine();
            string slowo = null;
            string odszyfrowanawiadomosc = null;
            for (int x = 0; x < odszyfrowane.Length; x++)
            {
                if (tablica2[x] != '/')
                {
                    slowo = slowo + tablica2[x];
                }
                else {
                    if (slowo == null)
                    {
                        odszyfrowanawiadomosc = odszyfrowanawiadomosc + ' '; 
                    }
                    else if (morse2.ContainsKey(slowo))
                    {
                        odszyfrowanawiadomosc = odszyfrowanawiadomosc + morse2[slowo];
                    }                    
                    slowo = null;
                }                
            }
            textBox3.Text = odszyfrowanawiadomosc;
            Console.WriteLine("Odszyfrowana wiadomość to: " + odszyfrowanawiadomosc);            
            MessageBox.Show(Convert.ToString(buffer.Length));      
            output = new NAudio.Wave.DirectSoundOut();
                output.Init(new NAudio.Wave.WaveChannel32(wave));
                output.Play();            
            }
        private void DisposeWave()
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Stop();
                output.Dispose();
                output = null;
            }
            if (wave != null)
            {
                wave.Dispose();
                wave = null;
            }
        }

       
    }
}
