/*
    В качестве домашнего задания нужно создать класс EventSender, каждую секунду отправлять 
    вызывать случайное событие. Событие должно быть получено другим классом Observer и выведено 
    на консоль.
 Задача:
    1. Написать класс EventSender а также некоторую обвязку классов, позволяющие этот класс 
    протестировать.
    2. Класс EventSender должен каждую секунду вызывать случайное событие из 4х доступных 
    (Event1, Event2, Event3, Event4).
    3. Ни одного класса не должно быть подписано на Event1.
    4. Один класс должен быть подписан на Event2 и при его срабатывании писать в консоль 
    “Event 2 принят”
    5. Три объекта класса должны быть подписаны на Event3 и при его срабатывании писать в консоль 
    “Event 3 принят классом с ID <ID класса>”
    6. Один класс должен быть подписан на Event4 и при его срабатывании блокировать поток, 
    в котором выполняется, до прихода следующего сообщения от EventSender.
 */

namespace EventsTest
{
    class Observer
    {
        int _id;
        public Observer(int id)
        {
            _id = id;
        }

        public void SimpleAccept(object sender, MyEventArgs e)
        {
            Console.WriteLine($"Event #{e.Number} accepted");
        }
        public void AcceptWithID(object sender, MyEventArgs e)
        {
            Console.WriteLine($"Event #{e.Number} accepted by Observer #{this._id}");
        }
        public void BlockingAccept(object sender, MyEventArgs e)
        {
            Console.WriteLine($"Event #{e.Number} accepted, thread blocked");
            Thread.CurrentThread.Join();
        }
    }
}