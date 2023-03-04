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

    class Program
    {
        public static void Main()
        {
            EventSender eventSender = new EventSender();
            List<Observer> observers = new List<Observer>();

            for (int i = 0; i < 5; i++)
            {
                observers.Add(new Observer(i));
            }
            eventSender.Event2 += observers[1].SimpleAccept;
            eventSender.Event3 += observers[2].AcceptWithID;
            eventSender.Event3 += observers[3].AcceptWithID;
            eventSender.Event4 += observers[4].BlockingAccept;
            for(int i = 0; i < 5; i++)
            { 
                ThreadStart threadStart = new ThreadStart(eventSender.Run);
                Thread thread = new Thread(threadStart);
                thread.IsBackground = true;
                thread.Start();
            }
            Thread.Sleep(10000); // waiting 10 seconds for everything to finish
            //all threads are background, so they will all stop after
            //the application closes in 10 seconds in any case
        }
    }
}