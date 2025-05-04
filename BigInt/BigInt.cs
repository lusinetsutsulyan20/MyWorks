using System;
class Program {
    public static string Add (string a, string b){
        if (a == "0"){
            return b;
        } else if (b == "0"){
            return a;
        }
        
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
        return res;
    }
    
    public static string subtract (string a, string b){
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
        Console.WriteLine(Program.Add ("99", "6"));
        Console.WriteLine(Program.subtract("99", "6"));
        
    }
}
