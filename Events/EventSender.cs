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
    public class EventSender
    {
        public event EventHandler<MyEventArgs> Event1;
        public event EventHandler<MyEventArgs> Event2;
        public event EventHandler<MyEventArgs> Event3;
        public event EventHandler<MyEventArgs> Event4;

        public void Run()
        {
            Random random = new Random();
            while (true)
            {
                int randomNumber = random.Next(1, 5);
                switch (randomNumber)
                {
                    case 1:
                        Event1?.Invoke(this, new MyEventArgs(1));
                        break;
                    case 2:
                        Event2?.Invoke(this, new MyEventArgs(2));
                        break;
                    case 3:
                        Event3?.Invoke(this, new MyEventArgs(3));
                        break;
                    case 4:
                        Event4?.Invoke(this, new MyEventArgs(4));
                        break;
                }
                Thread.Sleep(1000);
            }

        }
    }
}