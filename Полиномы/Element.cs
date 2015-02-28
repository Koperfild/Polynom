using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Полиномы
{
    //Делать проверку соответствия левых и правых скобок. Через стэк или ещё как
    class Syshnost
    {
        public string element{get;set;}
        public double coef{get;set;}
        public Syshnost(string elem)
        {
            //Можно потом доделать, указав вначале единственный способ ввода (с * или без).Тут приведение к выбранному стандарту хранения и обработки сущностей
            //И упорядочение членов по индексу
            orderByIndex();
            //castToConventionalLook();
            //делать всё lowercase или uppercase
        }
        void castToConventionalLook()
        {
            //приведение к выбранному стандарту
        }
        void orderByIndex()
        {
            //order element
        }
        bool equalbyElem(Syshnost S1, Syshnost S2)
        {
            return (S1.element.CompareTo(S2.element) == 0);                
        }
        public Syshnost sum2Syshnosti(Syshnost S){
            if (this.equalbyElem(this,S)){
                S.coef=this.coef+S.coef;
            }
            if (S.coef==0) return null;
            else return S;
        }
        public Syshnost multiply2Syshnosti(Syshnost S){//null if coef = 0
            S.coef=this.coef*S.coef;
            if (S.coef!=0){
                S.element=string.Concat(S.element,this.element);
                //Закоментить строчку ниже если не реализовано
                S.castToConventionalLook();
                S.orderByIndex();
                return S;
            }
            else return null;
        }
        public EntitiesArray multiplyByEntitiesArray(List<Syshnost> S){
            for (int i=0;i<S.Count;++i){
                S[i]=this.multiply2Syshnosti(S[i]);
                if (S[i]==null){
                    S.RemoveAt(i);
                }
            }
            if (S.Count==0) return null;
            else{
                EntitiesArray E=new EntitiesArray(S);
                return E;
            }
        }
    }
    class EntitiesArray{
        List<Syshnost> Massiv = new List<Syshnost>();
        public EntitiesArray(){}
        public EntitiesArray(List<Syshnost> S){
            this.Massiv=S;
        }

        public void summarize()
        {
            //Тут короче удаление лишних сущностей и слияние одинаковых в одну с новым коэффициентом
            //Можно упорядочить полином по индексам
        }
        public bool readSyshnost(string polynom,out bool )
        {
            //Тут короче читаем строку и откусываем первый член многочлена, укорачиваю строку полинома
            //если сущность (член полинома) без скобки справа, то false, инача true. 
            return true;
        }
        public EntitiesArray TreeWalk(PolynomTree P){
            EntitiesArray E=new EntitiesArray();
            EntitiesArray BranchArray = new EntitiesArray();
            if (P.child.Count!=0){
                for (int i=0;i<P.child.Count;++i){
                    BranchArray = TreeWalk(P.child[i]);
                    E.Massiv.AddRange(P.S.multiplyByEntitiesArray(BranchArray.Massiv).Massiv);
                }
            }
            else{
                //Тут короче ёбнули ДИМУ
                E.Massiv.Add(P.S);
                //return (P.parent.S.multiplyByEntitiesArray(E.Massiv));
                return E;
            }
            return E;
        }
    }
    class PolynomTree{
        public List<PolynomTree> child{get;set;}
        public PolynomTree parent{get;set;}
        public Syshnost S{get;set;}
        public static PolynomTree Root{get;set;}
        public static PolynomTree currentNode{get;set;}//А нужно ли? ДЛя текущего положения в
        public void addSyshnostNode(Syshnost S){
            PolynomTree P=new PolynomTree();
            this.child.Add(P);
            P.parent=this;
            P.S=this.S;
        }
        public EntitiesArray calcPolynom(string[] polynomParts){
            //Делать это вне и передавать уже массив строк parts
            //string[] parts=polynom.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
            if (polynomParts.Length==0) return null;
        }
    }
    class CalculatePolinom
    {
        string polynom;

        public string calc(string polynom){
            if (!polynomEmpty())
            {
                EntitiesArray MassivSyshnostei = new EntitiesArray();
                MassivSyshnostei.readSyshnost()
            }

        }
        public bool polynomEmpty(){
            //Тут короче после чтения readSyshnost надо проверять оставшуюся строку polynom на отсутствие членов полинома. 
            //Т.е. могут остаться огрызки из скобок или ещё чего
            //Если остались только скобки разные return true;else return false;
        }
    }        
}
