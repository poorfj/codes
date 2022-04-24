// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Linq;
//用_替代减号
char[] operatorChars = { '+', '_', '×', '÷' };
char[] numbChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
//用以得知是第几个运算符
int operatorsPositionIndex = 0;
//用以得知字符在字符串的什么位置
int stringIndex = 0;
//用以得知是否最后一个高优先级运算符
int numbsOfOperators = 0;
int numbsOfHightPriorityOperators = 0;
int numb1lenght = 0;
int numb2lenght = 0;
string GitTest = "用以测试Git";
//用-表示负数表示_减号
string text = "-8×-5+-6÷3";
System.Console.WriteLine($"Original text: '{text}'");



ArrayList numbsAr=new ArrayList();
ArrayList operatorsAr = new ArrayList();
string[] numbsArs = text.Split(operatorChars);


//把数字移进ArrayList
foreach (var word in numbsArs)
{
    numbsAr.Add(word);
}

//第一次打印
foreach (var item in numbsAr)
{
    Console.WriteLine(item);
}
do
{
    if (IsThereHightPriorityOperator(text))
    {
        GetIndexHP(text);

        Calculate(stringIndex);
    }
    else
    {
     GetIndex(text);
    Calculate(stringIndex);
     }
} while (IsThereOperatot(text)) ;

foreach (var item in numbsAr)
{
    Console.WriteLine(item);
}



//把字符转成Double
double toStringAndTryParse(object? num)
{
    double result;
   double.TryParse(num.ToString(),out result);
    return result;
}
void GetIndexHP(string tx)
{
    //每次调用自动重置
    operatorsPositionIndex = 0;
    stringIndex= 0;
    foreach (var item in tx)
    {
        if (item == '×' || item == '÷')
        {
            break;
        }
        else if (item == '+' || item == '_')
        {
            operatorsPositionIndex += 1;
            stringIndex += 1;
        }
        else
        {
            stringIndex += 1;
        }
    }
}
void GetIndex(string tx)
{
    //每次调用自动重置
    operatorsPositionIndex = 0;
    stringIndex = 0;
    foreach (var item in tx)
    {
        if (item == '+' || item == '_')
        {
            break;
        }
        else
        {
            stringIndex += 1;
        }
    }
}
bool IsThereOperatot(string tx)
{
    numbsOfOperators = 0;
    foreach (var item in tx)
    {
        if (item == '×' || item == '÷'||item == '+' || item == '_')
        {
            numbsOfOperators += 1;
        }
    }
    if (numbsOfOperators > 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}
bool IsThereHightPriorityOperator(string tx)
{
    numbsOfHightPriorityOperators = 0;
    foreach (var item in tx)
    {
        if (item == '×' || item == '÷')
        {
           numbsOfHightPriorityOperators += 1;
        }
    }
    if (numbsOfHightPriorityOperators > 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}
void Calculate(int STRindex)
{
    double newNum=0;
    char c=text[STRindex];
    switch (c)
    {
        case '+':
            newNum = toStringAndTryParse(numbsAr[operatorsPositionIndex]) + toStringAndTryParse(numbsAr[operatorsPositionIndex + 1]);
            break;
        case '_':
            newNum = toStringAndTryParse(numbsAr[operatorsPositionIndex]) - toStringAndTryParse(numbsAr[operatorsPositionIndex + 1]);
            break;
        case '×':
            newNum = toStringAndTryParse(numbsAr[operatorsPositionIndex]) * toStringAndTryParse(numbsAr[operatorsPositionIndex + 1]);
            break;
        case '÷':
            newNum = toStringAndTryParse(numbsAr[operatorsPositionIndex]) / toStringAndTryParse(numbsAr[operatorsPositionIndex + 1]);
            break;
        default:
            break;
    }
    GetTwoNumbsLenght();
    text = text.Remove(STRindex - numb1lenght, numb1lenght + numb2lenght + 1);
    text = text.Insert(STRindex - numb1lenght,newNum.ToString());
    numbsAr[operatorsPositionIndex] = newNum;
    numbsAr.RemoveAt(operatorsPositionIndex + 1);

}
void GetTwoNumbsLenght()
{
    numb1lenght = 0;
    numb2lenght = 0;
    string n1 = numbsAr[operatorsPositionIndex].ToString();
    string n2 = numbsAr[operatorsPositionIndex+1].ToString();
    foreach (var item in n1)
    {
        numb1lenght += 1;
    }
    foreach (var item in n2)
    {
        numb2lenght += 1;
    }
}

//foreach (var item in text)
//{
//    if (item == '×' || item == '÷')
//    {
//        double newNum = 0;
//        if (item == '×')
//        {
//            newNum = toStringAndTryParse(numbsAr[operatorsPositionIndex]) * toStringAndTryParse(numbsAr[operatorsPositionIndex + 1]);
//        }
//        else
//        {
//            newNum = toStringAndTryParse(numbsAr[operatorsPositionIndex]) / toStringAndTryParse(numbsAr[operatorsPositionIndex + 1]);
//        }

//        numbsAr[operatorsPositionIndex] = newNum;
//        numbsAr.RemoveAt(operatorsPositionIndex + 1);
//        //删除原始字符串里以计算的两个数字和一个运算符,如何删除正确位置
//        text = text.Remove(operatorsPositionIndex - 1, operatorsPositionIndex + 2);
//        //打印数组，无实际作用
//        Console.WriteLine($"text after{text}");
//        foreach (var word in numbsAr)
//        {
//            Console.WriteLine(word);
//        }
//        break;
//    }
//    else if (item == '+' || item == '-')
//    {
//        operatorsPositionIndex += 1;
//    }
//}