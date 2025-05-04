// Ստեղծել MyList<T> կլասը, որն իմպլեմենտում է IReadBox<out T> կովարիանտ ինտերֆեյսը և IWriteBox<in T> կոնտրավարիանս ինտերֆեյսը:
// IReadBox-ն ունի T տիպի արժեք վերադարձնող this[int index] ինդեքսերը:
// IWriteBox-ն ունի void Add(T item) մեթոդը
// MyList-ն ինտերնալ ձևով կարող է օգտվել ստանդարտ LIst<T>-ից, այն պետք է ապահովի T տիպի տվյալներն ինդեքսով կարդալու
//  և Add- ի միջոցով ավելացում անելու ֆունկցիոնալությունը:

// Որպեսզի ստուգեք կովարիանս/կոնտրավարիանս առանձնահատկությունները, մշակեք թեստային ստատիկ մեթոդներ, 
// որոնք համապատասխանաբար սպասում են IReadBox, IWriteBox ինտերֆեյսերը

using IReadBoxNamespace;
using IWriteBoxNamespace;

namespace MyListNamespace
{
    public class MyList<T> : IReadBox<T>, IWriteBox<T>
    {
        private List<T> _items;
        public MyList()
        {
            _items = new List<T>();
        }
        public void Add(T item)
        {
            _items.Add(item);
        }
        public T this [int index] 
        {
            get
            {
                return _items[index];
            }
        }

        
    }
}