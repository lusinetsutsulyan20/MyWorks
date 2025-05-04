using System;
class Program {
    public static string Add (string a, string b){
        if (a == "0"){
            return b;
        } else if (b == "0"){
            return a;
        }
        
        //check is first number negative or positive
        bool firstIsNegative = false;
        bool secondIsNegative = false;
        string firstNumber;
        string secondNumber;
        
        char[] ar = a.ToCharArray();
        if (ar[0] == '-'){
            firstIsNegative = true;
            for (int i = 1; i < ar.Length; i++){
                ar[i - 1] = ar[i];
            }
            string tmpAr = new string (ar);
            firstNumber = tmpAr.Substring(0, tmpAr.Length - 1);
        } else {
            firstNumber = new string (ar);
        }
        
        
        // check is second number is negative or positive
        char[] br = b.ToCharArray();
        if (br[0] == '-'){
            secondIsNegative = true;
            for (int i = 1; i < br.Length; i++){
                br[i - 1] = br[i];
            }
            string tmpBr = new string (br);
            secondNumber = tmpBr.Substring(0, tmpBr.Length - 1);
        } else {
            secondNumber = new string (ar);
        }
        
        //two cases are here
        if ((firstIsNegative == false) && (secondIsNegative == true))
        {
            return Subtract(firstNumber, secondNumber);
        } 
        else if ((firstIsNegative == true) && (secondIsNegative == false))
        {
            return Subtract(firstNumber, secondNumber);
        } 
        
        //our all logic
        int maxLength = (a.Length > b.Length) ? (a.Length) : (b.Length);
        
        char[] result = new char[maxLength + 1];
        
        int sumBit = 0;
        int carryBit = 0;
        int count = 0;
        
        int fistIndex = a.Length - 1;
        int secondIndex = b.Length - 1;
        
        int firstBit = 0;
        int secondBit = 0;
        
        for (int i = (maxLength); i > 0; i--){
            if (fistIndex >= 0){
                firstBit = (a[fistIndex] - '0');
            } else {
                firstBit = 0;
            }
            
            if (secondIndex >= 0){
                secondBit = (b[secondIndex] - '0');
            } else {
                secondBit = 0;
            }
            
            count = firstBit + secondBit + carryBit;

            if (count > 9){
                sumBit = count - 10;
                carryBit = 1;
            } else {
                sumBit = count;
                carryBit = 0;
            }
            
            result[i] = (char)('0' + sumBit);
            --fistIndex;
            --secondIndex;
        }
        result[0] = (char)('0' + carryBit);
            
        string res = new string(result).TrimStart('0');
        
        //here is the third case
        if ((firstIsNegative == true) && (secondIsNegative == true)) {
            char[] forNegatives = new char[res.Length + 1];
            
            forNegatives[0] = '-';
            for (int i = 1; i < res.Length; i++){
                forNegatives [i] = res[i - 1];
            }
            string forNeg = new string(forNegatives);
            return forNeg;
        }
        
        return res;
    }


    //Subtract
    public static string Subtract (string a, string b){
        if ((a == "0") || (b == "0")){
            return "0";
        } 
        
        //check is first number negative or positive
        bool firstIsNegative = false;
        bool secondIsNegative = false;
        string firstNumber;
        string secondNumber;
        
        char[] ar = a.ToCharArray();
        if (ar[0] == '-'){
            firstIsNegative = true;
            for (int i = 1; i < ar.Length; i++){
                ar[i - 1] = ar[i];
            }
            string tmpAr = new string (ar);
            firstNumber = tmpAr.Substring(0, tmpAr.Length - 1);
        } else {
            firstNumber = new string (ar);
        }
        
        
        // check is second number is negative or positive
        char[] br = b.ToCharArray();
        if (br[0] == '-'){
            secondIsNegative = true;
            for (int i = 1; i < br.Length; i++){
                br[i - 1] = br[i];
            }
            string tmpBr = new string (br);
            secondNumber = tmpBr.Substring(0, tmpBr.Length - 1);
        } else {
            secondNumber = new string (ar);
        }
        
        // here is two cases
        if ((firstIsNegative == false) && (secondIsNegative == true)) // 99 - (-6)
        {
            Console.WriteLine(firstNumber + " " + secondNumber);
            return Add(firstNumber, secondNumber);   
        } 
        else if ((firstIsNegative == true) && (secondIsNegative == false)) // -99 - 6
        {
            string ress = Add(firstNumber, secondNumber);
            Console.Write (firstNumber + " " + secondNumber + "  ");
             Console.WriteLine ("ress is " + ress + "  ");
            char[] tmpRes = new char[(ress.Length + 1)];
           
            tmpRes[0] = '-';
            for (int i = 1; i < ress.Length; i++){
                tmpRes [i] = ress[i - 1];
            }
            string forTmpRes = new string(tmpRes);
            return forTmpRes;
        } 
        else if ((firstIsNegative == true) && (secondIsNegative == false))
        {
            string newTmp = Add(firstNumber, secondNumber);
            
            char[] newTmpArr = new char[newTmp.Length + 1];
            
            newTmpArr[0] = '-';
            for (int i = 1; i < newTmp.Length; i++){
                newTmpArr [i] = newTmp[i - 1];
            }
            string newTmpRes = new string(newTmpArr);
            return newTmpRes;        
        }
        
        //logic
        int maxLength = (a.Length > b.Length) ? (a.Length) : (b.Length);
        
        
        char[] newB = new char[maxLength];
        
        int index = b.Length - 1;
        
        for (int i = maxLength - 1; i >= 0; i--){
            int tmp = 0;
            if (index >= 0){
                tmp = '9' - b[index];
            } else {
                tmp = 9;
            }
            newB[i] = (char)(tmp + '0');
            --index;
        }
        
        string tmpB = new string (newB);   
        string result = Add (tmpB, "1");
        
        string tmpSum = Add (result, a);
        string res = tmpSum.Substring(1);
        
        return res;
    }
    
    
    static void Main() {
        // Console.WriteLine(Program.Add ("99", "6")); // +
        // Console.WriteLine(Program.Add ("-99", "6")); // 
        // Console.WriteLine(Program.Add ("99", "-6")); // +
        // Console.WriteLine(Program.Add ("-99", "-6")); // 
        
        // Console.WriteLine(Program.Subtract ("99", "6")); // +
        Console.WriteLine(Program.Subtract ("-99", "6")); // -
        Console.WriteLine(Program.Subtract ("99", "-6")); // -
        // Console.WriteLine(Program.Subtract ("-99", "-6")); // 
        
    }
}
