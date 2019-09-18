using System;
using System.Collections.Generic;
using Castle.Windsor;

namespace DddCoreExample.Domain
{
    public static class DomainEvents
    {
        [ThreadStatic]
        private static List<Delegate> actions;

        private static IWindsorContainer Container;

        public static void Init(IWindsorContainer container)
        {
            Container = container;
        }

        public static void Register<T>(Action<T> callback) where T : DomainEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }
            actions.Add(callback);
        }

        public static void ClearCallbacks()
        {
            actions = null;
        }

        public static void Raise<T>(T args) where T : DomainEvent
        {
            if (Container != null)
            {
                foreach (var handler in Container.ResolveAll<Handle<T>>())
                {
                    handler.Handle(args);
                }
            }

            if (actions != null)
            {
                foreach (var action in actions)
                {
                    if (action is Action<T>)
                    {
                        ((Action<T>)action)(args);
                    }
                }
            }
        }
    }
}
