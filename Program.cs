using System;
using System.Linq;
using System.Text;
public class Testfiscal  
{  
    public static void Main() 
    {
        // execution time calculator

        var watch = System.Diagnostics.Stopwatch.StartNew();

        // Variable declaration

    string gender = "";
    string surN,name,vowel1,dateInput,monthCode="";
    StringBuilder surName = new StringBuilder();
    StringBuilder secondName = new StringBuilder();
    StringBuilder fiscalCode = new StringBuilder();
    var gcode = "";
    int i, len,cons;
    
    // Taking inputs
    Console.WriteLine("\n              ... Fiscal Code ...          ");
    Console.WriteLine("   ... Please input the following data ... \n");
    
    Console.Write("Name : ");
    name = Console.ReadLine();	
    
    Console.Write("Surname : ");
    surN = Console.ReadLine();

    Console.Write("Gender : ");
    gender = Console.ReadLine();	

    Console.Write("Date of Birth: ");
    dateInput = Console.ReadLine();
    
    //Print inputs
    Console.WriteLine("\n");
    Console.WriteLine("name: {0}",name);
    Console.WriteLine("surname: {0}",surN);
    Console.WriteLine("gender: {0}",gender);
    Console.WriteLine("dob: {0}",dateInput);

    // Processing Surname
    cons = 0;
    vowel1 ="";
    len = surN.Length; 

    for(i=0; i<len; i++) // checking consonants in surname
    {
        if(surN[i] =='a' || surN[i]=='e' || surN[i]=='i' || surN[i]=='o' || surN[i]=='u' || surN[i]=='A' || surN[i]=='E' || surN[i]=='I' || surN[i]=='O' || surN[i]=='U')
        {
            vowel1 = surN[i].ToString();
        }
        else if((surN[i]>='a' && surN[i]<='z') || (surN[i]>='A' && surN[i]<='Z'))
        {
            cons++;
            surName.Append(surN[i].ToString().ToUpper());
        }  
    }

    if(cons <= 2)
    {
        surName.Append(vowel1.ToUpper());
    }
    if (surName.Length <= 2)
    {
        surName.Append("X");
    }
    if (surName.Length < 1)
    {
        surName.Append("X");
    }

    //Processing second name
    cons = 0;
    vowel1 ="";
    len = name.Length; 

    for(i=0; i<len; i++)   // checking consonants in the second name
    {
        if(name[i] =='a' || name[i]=='e' || name[i]=='i' || name[i]=='o' || name[i]=='u' || name[i]=='A' || name[i]=='E' || name[i]=='I' || name[i]=='O' || name[i]=='U')
        {
            vowel1 = name[i].ToString();
        }
        else if((name[i]>='a' && name[i]<='z') || (name[i]>='A' && name[i]<='Z'))
        {
            cons++;
            secondName.Append(name[i].ToString().ToUpper());
        }  
    }

    if(cons <= 2)
    {
        secondName.Append(vowel1.ToUpper());
    }
    if (secondName.Length <= 2)
    {
        secondName.Append("X");
    }
    if (secondName.Length < 1)
    {
        secondName.Append("X");
    }

    //Processing date
    int date = 0;
    int month = 0;
    string year = "";

    if (dateInput != null)
    {
        string[] all = dateInput.Split('/');
        date = Int16.Parse(all[0]);
        month = Int16.Parse(all[1]);
        if(all[2].Length>3)
            year = all[2].Substring(2,2);

    }

    //month code
    switch(month)
        {
            case 1:   monthCode = "A"; break;
            case 2:   monthCode = "B"; break;
            case 3:   monthCode = "C"; break;
            case 4:   monthCode = "D"; break;
            case 5:   monthCode = "E"; break;
            case 6:   monthCode = "H"; break;
            case 7:   monthCode = "L"; break;
            case 8:   monthCode = "M"; break;
            case 9:   monthCode = "P"; break;
            case 10 : monthCode = "R"; break;
            case 11 : monthCode = "S"; break;
            case 12 : monthCode = "T"; break;
            default:Console.WriteLine("invalid");break;
        }
   
    //gender code
    {

        if (gender == "female" || gender == "F" || gender == "f")
        {
            gcode = (date + 40).ToString();

        }
        if (gender == "male" ||gender == "M" || gender == "m")
        {
            if (date < 10)
            {
                gcode = date.ToString().Insert(0, "0");
            }

        }
    }
    // Output & fiscal code 
    
    //Appending Surname
    fiscalCode.Append(surName.ToString().Substring(0, 3));
    
    //Appending SecondName
    fiscalCode.Append(secondName.ToString().Substring(0, 3));
    
    //Appending Year
    fiscalCode.Append(year.ToString());
    
    //Appending Month
    fiscalCode.Append(monthCode);
    
    //Appending date
    fiscalCode.Append(gcode.ToString());
    
    //output

    Console.Write("Fiscal Code is ");
    
    Console.WriteLine(fiscalCode.ToString());
    
    //Time calculator stops
    watch.Stop();
    Console.WriteLine($"Total Execution Time: {watch.ElapsedMilliseconds} ms");
 }
}