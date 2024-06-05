using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Tubes3_YUBIsa
{
    internal class DatabaseConnector
    {
        private string connectionString;
        private List<string> names = [];

        public DatabaseConnector(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InitializeDatabase()
        {
            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();

                    if (TableExists(connection, "sidik_jari") && TableIsEmpty(connection, "sidik_jari"))
                    {
                        InsertInitialFingerprint(connection);
                        UpdateBioToAlay(connection);
                        MessageBox.Show("Database has been updated");
                    }
                }
                catch
                {
                    MessageBox.Show("Can't connect to database");
                }

            }
        }

        private bool TableExists(MySqlConnection connection, string tableName)
        {
            using (var command = new MySqlCommand($"SHOW TABLES LIKE '{tableName}'", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        private bool TableIsEmpty(MySqlConnection connection, string tableName)
        {
            using (var command = new MySqlCommand($"SELECT COUNT(*) FROM {tableName}", connection))
            {
                return Convert.ToInt32(command.ExecuteScalar()) == 0;
            }
        }

        private void InsertInitialFingerprint(MySqlConnection connection)
        {
            string directoryPath = @"C:\Users\USER\Kuliah\SEMESTER4\Sttrategi Algoritma\Tubes\Tubes3 - YUBIsa\SOCOFing\Real";
            string[] files = Directory.GetFiles(directoryPath, "*.bmp");
            names = GetAllNamesFromBiodata(connection);
            string query = "INSERT INTO sidik_jari (berkas_citra, nama) VALUES (@Content, @Name)";

            foreach (string filePath in files)
            {
                string fileName = Path.GetFileName(filePath);

                string ascii = BinaryToAsciiConverter.ConvertToAscii(FingerprintProcessor.ConvertImageToBinary(filePath));
                int index = ExtractImageId(fileName) - 1;
                if (index < 0)
                {
                    continue;
                }

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Content", ascii);
                    command.Parameters.AddWithValue("@Name", names[index]);
                    command.ExecuteNonQuery();
                }
            }
        }

        private List<string> GetAllNamesFromBiodata(MySqlConnection connection)
        {
            List<string> namesList = [];
            string query = "SELECT nama FROM biodata ORDER BY nama ASC";

            using (MySqlCommand command = new(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString("nama");
                        namesList.Add(name);
                    }
                }
            }

            return namesList;
        }

        private int ExtractImageId(string fileName)
        {
            var match = Regex.Match(fileName, @"^(\d+)_"); // Untuk mendapatkan nomor di depan nama yang formatnya biasanya "d_M_..." dengan d adalah angka
            if (match.Success)
            {
                return int.Parse(match.Groups[1].Value);
            }
            return -1; // Return -1 if the participant ID cannot be extracted
        }

        private void UpdateBioToAlay(MySqlConnection connection)
        {
            List<string> alayNames = ["B6l nppr", "4bb mcv4gH", "4Bdl m3hmeT", "bR b664lly", "dl1n 4yl3n", "Dd dM5chk", "De lyDF0Rd", "4dy hl5by", "ftn htchN", "1l5Un 4l5", "lyn pNRth", "L5Tr lndre", "L55nDr bdc", "L5s4ndr JRemh", "l3TH o' fnn", "4lX b0cCk", "4LX frln6", "lex mrrnr", "lf 6vRn", "4lc 0hRt", "llN frmn", "lln 5hTTl", "Ll 5T4nland", "ll 3l5Tr", "LvRA nl35", "mBr5 cnnCH", "mbr5 muNf13ld", "mby 6dd5", "M3lE 1bbtt", "4mty tRrN", "anbl jM", "4nL5 lndup", "NLi5 dUnr6", "nDI 5km", "NdR mNt4Th", "andr0mch 5vll", "n3T minchell", "Njl 6lks", "aNjLa 5hcKltn", "nN 5T4nbrd63", "nN4bllA Mcn4Ll3Y", "nncrnn cWl3s", "n5lm R5tn", "NTn1 tllrtn", "r bruCe", "4RdyTh 5mD", "rlN pett13", "rln 5Hys", "rlyN ThorntN-D3WhrSt", "rlyn BRM", "rv rkstrw", "atlnt3 Ms51ngbrD", "U65t mCvron", "rR4 trV3n", "rthr labB", "Vryl Chvrst0n", "4VV4h Prmtr", "Yn klMRrY", "BB3tt3 mcf", "bn K1lbE", "bnk hckr", "brb DinS", "bRClY 6l54n", "bRon mnrd", "BrrT hR6Rv3", "B4rtL ort", "BrTlTt 5kll0n", "B3ll belly", "B cll4ndr", "Bndt 51mntT", "Bnd1ct tThr", "Bnjmn v5ytkn", "B3R6t Rlln6", "Brn b4rb3ry", "Bvr 6rlk", "bl4K brns", "Bl4Nch3 wndr4ch", "bLnCh wrRll", "bLs5 phlliPps", "b0beTT 5tdd", "b0nN3 wathll", "br4dny tmsTt", "brndn 4nT4LfFy", "brnd5E mTimr", "brndtr v51C", "brNn mCrb3rT5", "brTt jO5LVch", "Br14Nn mrnR", "brdd haK", "brNnY GrC", "BUnn1 c4nll5", "Cl WolFrth", "CM3y trb4Rd", "crmNcT brk5", "crMn 3Rk", "cs HnsOn", "CThRNe h0k5", "ctr1n sCh5tL", "ccl1 chMbrln", "c3lSt dkln", "cLEstyn 6thrll", "chntll BCknhll", "chrm41n 0rmrd", "ChRmN mCk", "cH4Nc3 w0rLd", "cheN kL6rv", "chry bRT3l", "CHr5tN hkk1n6", "cHri5t0P3r crdlL0", "cnd Mudtt", "ClRk3 hnd3r", "clyBrn spLl55y", "clem lRent", "cl1M vnT", "Col5 ahrn", "coLlt MCcrTnY", "Cll 4N53Lm", "C0N5tNcy br4dLy", "cr4l gl55P", "C0rll tlLT", "cr5s mCr3R", "CornL jm5", "crrY bvrstck", "c5 brtlM1Jc2Yk", "C5m md50n", "cr4wfrD mCshrE", "cr5tAn M5dll", "cyMbre 5tRrr", "cynd1 r55brK", "dN cvll", "D4nc4 rnnCk", "dAnLa c0xn", "Dnnl mchnry", "dr Ells", "dreLl lghTbUrNe", "dr3ll v6Nr0n", "Drryl Val3ri", "dr5 mDns", "d4RY4 km5tR", "Db l Bt", "dd c0N6RVe", "dd1 Jws", "dL0r5 wLN3", "deMtR cH41m", "d3rrn dyt", "dvn 5r", "dVn 5ys3lnd", "dW 51nr", "d4nn shlL0", "dg0 h4u5", "dlLn 5ctch30n", "D1mTR mttn", "D1X BRtLn", "DM1tr 1n63r", "dLL bMnT", "dlLY Tm0Ny", "dLph mrhLl", "Dnny k4MP5h3LL", "drn k1n65wrth", "dry DttR3ll", "drAn d4Thrd6", "dr0thy bLCkSlNd", "DRry dYmnD", "DRthY PnlL", "Dtt pEtrv5Ky", "DrnD mrTin", "DynN RMbLLW", "dyln Cwh6", "3chLl hcc4bY", "3dWn fRpp", "L0Nr hl", "l4nr slth", "lsb3t Mndl", "lK wyLy", "lln pYthn", "llwd 6cOBni", "Lm0 LrcHr", "elm pdrn", "M buddN", "3ml1 n3tt", "Ml v6ne", "mmlN q1n3Vn", "Nch dFtr", "rch lppn6tn", "rn5t n3l50n", "3rn35T rubRT", "Rn5TNe ld63", "Rny tR3v4n5", "tte d'H6H", "3gn1 b55m", "gn1u5 k1n6L5yd", "EvN6l1n opdn0rth", "V3Lyn pttndr6H", "Vn Mck1nl55", "FnChn 0tRm", "fRh 5n5", "frly mcculLch", "fYtH h4m5", "fdrc R055y", "Flc dYC", "flP D frr4r", "frdnnd 5Hwcrft", "fy Dln3Vo", "fdl pnN1", "flRr wll6hwy", "frnc5c Crt2n", "frder6 k1NncH", "fr3Lnd hll6lLY", "frmn rbl", "fltn clmnt", "Flv bdby", "6bR1ll LBRn", "643ln wiNWRd", "64rwd Rw452Kwc2", "6rW0d veLj35", "65Pr dyt", "6WN Ffrnch", "6wn 0nn5", "63NvV3 DvRn", "6r6 4nKr3tt", "grnn pr16", "6RRard jwtt", "6rr nRR35", "6rRY mN", "6rty p1n6", "G1cnt l0w3LL", "6lbrT rubY", "glbrt MTte", "g1Ls mnIch", "6nni prtTn", "6lndn 60mS", "6Lynd 5kf d'n6rthRp", "gdfr3y Rbrw", "6ld ldWck", "6ld4 wArdrpr", "grd3n Ry5", "6rntH3m hasnp", "6rt4n4 rdhill5", "6r3Nv1ll l5", "6rTl yell0wl3", "6rtn bckly", "6uNdOlN an6LN", "6lLrm 5kyl5", "6u55 prR", "655 ri2", "65tv bl0mfLd", "6uthrY 5UMmer5klL", "6Wendl3N bL", "hml r122n", "H4mlN mcbyl3", "Hrld fLT3", "harln rber50n", "HsheM PrmTR", "hshm lrnr", "ha5k3lL ptrn", "hndr5n ln6stn", "HpHZbh Sthr4N", "h3rB 4dly", "hERCL13 uc", "hR1brt grd5", "hrT w0F", "he5t 5h0n", "hw bL55", "hIld6rd wekl3y", "H0brt klment", "H0Rat0 BrvrY", "hRTn 3ch", "hu6h 5hnd", "hmfRd wlt5H4R", "humphrY 5hrtll", "HUntlY Sprn6", "hyCnth l4b0rd", "6n2 bROKf1ld", "1Lys bl2n", "1m6n ncy", "im6n3 PFFFeL", "1n6r4 T0wnDrw", "r5 4V35n", "rm4 stI6lL", "sDr Crct", "5k brndcci", "15H1 THUnNrclff", "1vy D'VR - hUNt", "j4cklyn c5TR", "jcKlyN 61Rd", "jCk hckF3ld", "jcqlIN 60dfr3y", "J1m 3ls", "jk0B gLlMr3", "jn3l frner", "jrrt andrzJ", "jyn3lL h4MpRcHt", "JFfry br2nr", "jfFy 52wndt", "jnn jhn", "Jr4m13 maR4G5", "jrmy jUrAsz", "jS5 cll35", "j3s5 Mr5", "Jeth KNd5n", "Jnn5 BrmFld", "jod M4ycY", "jdy knT", "j bwn", "jL lny", "jLLy 5hE4rsby", "jce Wnk5", "joL jrde5n", "JLy wl5", "jd CLV3r", "judN 6hdN", "jl5s drs", "kCy dych", "kl 5wnNrtN", "k5r Mc mK4n", "k4l bl4ckbrn", "Kr1tT4 cHrPln6", "Krl hN6rfrd", "k4rr 12hky", "ktl3n F5kw", "klc3y S4wny", "knnn O'hn", "KRk yrwd", "krrll kl1n2wg", "k1Mbr r4pH3l", "kmm fr5Hw4T3R", "kincAd esch", "kPp chURchrD", "kRb3 ElLtt", "krBy CP5y", "k03nrd B5n", "kr g4HgN", "kRll Chny", "krsH wh5tLCrft", "kr5t1N 5h1pmn", "kylL mWdtt", "kYlYNn wDdp", "LRne ns5n", "l4rY55 rDd0n", "lTrn 6rshk1N", "lREN Fcr", "l4rn D nsc", "l4Rtt3 fLlrtn", "lre mntlw", "l bRwll", "l6h 5lBy", "LEn3 rK", "ll wdwRTh", "ln4N LrrD", "Lenr4 aCKNhd", "l5h1 0'f06rty", "Le5h wtR5n", "L5Ley D66N5", "leX1 burnp", "lL dck", "LLYn k3RmNNs", "lnd luRt2n", "LNL 6ll3Dg", "L1t c1rald", "lVvY d1 brnrd", "Lz2 51n", "Llyd spk", "l0nN3 tnkl1N", "lrn5 barTlm", "LorN5 LftN", "l13 Wtkis5", "l5 l4n6tr", "lcn tTT", "LCno f4llw", "lYn5Y 0'hn3", "mdLn mccr34dY", "mDln 64Yn5", "mdliN sKll", "magD4 strn", "mgDL3n Lambtn", "m6d4LN mnchllo", "M1bl3 bXll", "M5on edlaNd", "mlclm 45tn6", "MaLnDe TfT", "mlrY cmpk1N", "m4nDy lntRy", "Mndy mRman", "mno 5tyl", "MNl MCFuL", "m4rcl brnOlet", "m4rgT Idel", "mRGUrt 3ssbR63r", "mr-jNn ClBrd6e", "Mritt bRckT", "m4rT4 5ms", "mry 4Tthw3", "mrkt4 v165", "mrLN Bekm4nn", "mRL4h bV5", "mrlN 5t3lf0x", "M4RlYn 5llTt", "Mrt3ll flK3Rd", "mrtHn4 Krm", "mrt3 hur5tn", "mTth1eu 5pRRwhwk", "m4x trL", "Mndl gr3gg5", "mrl arsy", "m3t4 wH4rltn", "Mchln h5MN", "mchl1n Nrmnv1ll", "mcK K3nnfck", "mK3l 5CRvn5", "MkKl 5bt", "M1rabel 6r6l1n", "M5h4 duf3r", "m15t 54llR", "MNR h4nn4", "mORgan4 brd5tCK", "Mr6n1C cwl", "Mr6nc4 FRnk5", "m0rty P1N5", "Nnc Bm5N", "nnCy CLletn", "nnni hll6TH", "Np RowLr", "nTLe bckl", "Nt551 bDnlL", "nthan 5coRfLd", "nathnl hnVy", "n4tK ln3BR6r", "naln V5Ly0nk", "nDdy hgbrn3", "n3d J5t", "nrT 35cT", "n3tT trBr66", "nTty jnnt", "n1cK 6rG0r1N", "ncky kncH", "Nc 6WM4N", "N1cl1n jkbvt5", "nk 4C3", "nklI taN5L", "n1Kl5 DrNbr00k", "nkl5 5crrTT", "nnntt B4RHm5", "nom FChn", "ctV5 4DRinLL", "ODTt LckhRt", "0dLl dgll", "lIy 5tbB5", "lLy b16g", "mr Brck3R", "rL Dw4ll", "rrN 6r6orv", "55 4mbl", "5w3ll 5twgll", "p4g hRrvEn", "pTR2 mllnbY", "p4Ttn Trr4N", "p4tt0n Lw5Ly", "ptTy jMm15N", "P4l LtHm", "prl kLl", "pRciv4l crTr", "pR 3NRQ", "p3t B3nnllck", "p3trnlL FNch", "pHlL Br6en", "ptr kN5ly", "prty chTt", "P0rty umbRt", "prNtc3 nVT", "qunn 5Q3lch", "rchl 6EtT1N65", "rcH3l p0WNEr", "R4mn rGNHRdt", "RphL nhl", "Rs14 h66Nb0ttm", "raynLl crCt", "rgN bruN3tT", "Rbcc 0' C0Nc4NNN", "rbkk4h dD5wll", "r6n4ld b4rm", "rD3r 5hdrcK", "RNlds 0wbRck", "rnwld B3rrsfrd", "rm whpln6T0n", "Rmy lndrN", "rn WttLtn", "rh0Nd mt2Kts", "R4Nn 1mlck", "rch3 brd5y", "rIcKy nly", "rck 4dn", "R54 p1r13", "RItCH HrT5", "r0dn ThrBOrn", "r0LLn5 bAgheN", "r0mn lyc3Tt", "RSbll rm5", "r5Ll albn50n", "r0slyn w1Nk", "ro55 mlLrd", "R0yl Brwtt", "r2nN Dbw", "r2L fwlty", "Rby 64n", "RD0lf McklR", "rPrt H1lLNd", "rthnn 6ull3N", "5aDe 5TnLnd", "54l0m3 35n", "5Lvtr fyld5", "5r6nT Br4tch", "5r rcCrdn", "55ha 3vs", "5aVIN cr3lmn", "Sv1n tnflD", "54X dym0tt", "5y frmlO", "5b5tN cLdrd6", "sK 23pln", "5el6 l1vRmr", "5ymR mr2Ll", "5hnn bygrAvs", "Shwn cYst3r", "shwn p4tl", "5hyN winScm", "5h3lH cRy5tL", "5hl4H rbbtT5", "5hEfFld 4nDR53N", "5hpheRd mcwhnn", "shRMy fYn35", "5hrl1n3 5tEbb1N65", "SB 5HRtN", "5bll4 PAbL", "s1bylL4 1T2c4k", "5dNn 6lfflL4n", "s1m kn4ppr", "5mmND5 bL", "s10x bFrd", "sKyLr RBBn", "5nnY WLlblve", "sp3n5 HW5n", "5tc LNt0n", "STc1 bNn0n", "5tFRd 4ndR3lL1", "5TRm wlkL0tT", "5k krdT", "5unny 50rby", "5ThrLn kNVN", "5yd3Ll Mcll5", "5Ylvn hlLn6", "SYmN sm5n", "5Ym0n p5n3Tt", "tbB 4MBr015", "tB1n4 FeR3N5d", "TNhY dmbR", "Tnny kmm", "tDD p5tlWht3", "t3Dor SlnD", "TEdR1c0 5tNw4Y", "tDR0 Dn5tt", "th3dric 0RpwD", "thbd 5HV1ll", "thom5 fly", "ThR5tn lmpL", "tb0ld grm35", "tmm1 frrrN", "t0bY bI5", "trr3 ckl3y", "tRc3 6lLn", "Tr5h sTnTfrD", "Lrk 1cM", "uly555 wal5h", "t b4mnt", "v4LNti m55ow", "vlrY bm", "vnC Bmpkn", "vlvT t5Cher5", "Ver styL5", "vr4D5 mttH55n", "vr1l d55ttr", "vErNK 5Le6h", "Vctr 5cn5", "Vlhlmn pdr", "vltT wh55N", "Vr6n4 cR0pTn", "w4ll5 4ndrS", "w4lli LmNG", "wNd m66n", "wdr sChFrstn", "wrnr c4ncllR1", "Ws 35chltte", "WldN twdDLl", "wlDn 1cbCC", "WldN yMN", "willY 65Kin6", "wl0w 5znt", "yNcY 6l42Y3r", "Zr brnn6N", "zb 6Llt", "23BlN vnnn6"];
            string query = "UPDATE biodata SET nama = @AlayName WHERE nama = @OriginalName";

            for (int index = 0; index < alayNames.Count; index++)
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AlayName", alayNames[index]);
                    command.Parameters.AddWithValue("@OriginalName", names[index]);
                    command.ExecuteNonQuery();
                }
            }
            
        }

        private List<FingerprintEntry> GetAllFingerprints()
        {
            List<FingerprintEntry> fingerprints = [];

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT berkas_citra, nama FROM sidik_jari";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FingerprintEntry entry = new()
                            {
                                BerkasCitra = reader.GetString("berkas_citra"),
                                Nama = reader.GetString("nama")
                            };
                            fingerprints.Add(entry);
                        }
                    }
                }
            }

            return fingerprints;
        }
    }

    public class FingerprintEntry
    {
        public string? BerkasCitra { get; set; }
        public string? Nama { get; set; }
    }
}
