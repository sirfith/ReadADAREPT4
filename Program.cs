// See https://aka.ms/new-console-template for more information
{
    DateTime date1 = DateTime.Now;
    string date2 = (date1.ToString("MMddyy"));
    Console.WriteLine("Date1: {0} ", date1);
    Console.Write("Input the Date: ");
    string date3 = Console.ReadLine();
    if (date3 == "")
    { date3 = date2; }
    string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    string penske = myDocuments + @"\Penske\ADAREPT.D" + date3 + @".txt";
    string bexarp = myDocuments + @"\Bexar\ADAREPTP.D" + date3 + @".txt";
    string bexart = myDocuments + @"\Bexar\ADAREPTDQ.D" + date3 + @".txt";
    string upenn = myDocuments + @"\UPenn\adarept.d" + date3 + @".txt";
    string target = myDocuments + @"\ADAREPTs\adarepts.d" + date3 + @".txt";
    // adarepAsync(fileName, target);
    //  delold(target);
    adarepAsync(penske, target, 'P');
    adarepAsync(bexarp, target, 'B');
    adarepAsync(bexart, target, 'B');
    adarepAsync(upenn, target, 'U');

    static async Task adarepAsync(string fileName, string target, char site)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        bool b = false;
        Console.WriteLine("Contents of {0}", fileName);
        foreach (string line in lines)
        {
            if (!((line.StartsWith(@"*")) || (line.StartsWith(@"1")) || line.Contains(@"***") || (line.Length < 2)))
            {
                if ((line.ToUpper().Contains(@"* FILE OPTIONS *")) || (line.ToUpper().Contains(@"CONTENTS OF PPT"))
                    || (line.ToUpper().Contains(@"* DELTA SAVE FACILITY *")))
                {
                    b = false;
                }
                if (line.Contains(@"U N U S E D   S T O R A G E") || (line.ToUpper().Contains(@"CONTENTS OF DATABASE")))
                {
                    b = true;
                }
                if (b || (line.ToUpper().Contains(@"DATA BASE NAME          =") || (line.ToUpper().Contains(@"DATA BASE NUMBER        ="))))
                {
                    Console.WriteLine(line);
                    string line1 = site + line;
                    Console.WriteLine(line1);
                }
            }
        }
    }
}