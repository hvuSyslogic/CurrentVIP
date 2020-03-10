using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleHostApp
{

   public class BlockingCollectionQueue

    {

        private BlockingCollection<object> _jobs= new BlockingCollection<object>();


        public BlockingCollectionQueue()

{

            var thread = new Thread(new ThreadStart(OnStart));

            thread.IsBackground = true;

            thread.Start();

        }


        public void Enqueue(object job)

        {

            _jobs.Add(job);

        }


        private void OnStart()

        { 

            foreach (var job in _jobs.GetConsumingEnumerable(CancellationToken.None))

            {

                Console.WriteLine(job);

            }

        }

    }


}
