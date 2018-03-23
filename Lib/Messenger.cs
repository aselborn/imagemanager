using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Lib
{
    public sealed class Messenger
    {

        private static readonly Dictionary<Type, HashSet<MessageRegistration>> _recievers = new Dictionary<Type, HashSet<MessageRegistration>>();

        public abstract class MessageRegistration
        {
            public object Reciever { get; set; }
        }

        public class MessageRegistration<T> : MessageRegistration
        {
            public Action<T> Action { get; set; }
        }

        //Entry 
        public static void Register<T>(object reciever, Action<T> action)
        {
            var messageType = typeof(T);
            if (!_recievers.ContainsKey(messageType))
            {
                _recievers.Add(messageType, new HashSet<MessageRegistration>());
            }

            _recievers[messageType].Add(new MessageRegistration<T>()
            {
                Reciever=reciever, Action = action
            });
        }


        public static void UnRegister<T>(object reciever)
        {
            var messageType = typeof(T);
            if (_recievers.ContainsKey(messageType))
            {
                var regObject = _recievers[messageType];
                var registration = regObject.FirstOrDefault(x => x.Reciever == reciever);

                if (registration != null)
                {
                    regObject.Remove(registration);
                    if (regObject.Count == 0)
                    {
                        _recievers.Remove(messageType);
                    }
                }

            }
        }

        public static void UnRegisterAll(object reciever)
        {
            
            foreach(var item in _recievers.Values)
            {
                var result = item.FirstOrDefault(p => p.Reciever == reciever);

                if (result!= null)
                {
                    item.Remove(result);
                }
            }
        }


        public void Execute<T>(T message)
        {
            var messType = typeof(T);
            if (!_recievers.ContainsKey(messType)) return;

            foreach(MessageRegistration<T> mr in _recievers[messType])
            {
                (mr.Action as Action<T>)(message);
            }
        }
    }
}
