/*
 * The MIT License (MIT)
 * 
 * Copyright (c) 2014  Austin Liang.
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
using FactoryDemo.Logics;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDemo
{
    public abstract class SampleBaseLogic : IDisposable 
    {
        public ILog _Log { get; private set; }

        protected SampleBaseLogic(Type _type)
        {
            _Log = LogManager.GetLogger(_type);
        }

        // runs the business logic here.
        // declare it as abstract method so that MUST be override.
        public abstract void Run();

        public void Dispose()
        {
            // you can implement 'IDisposable' interface and dispose / release any resource objects here.
            // for example, a database accessible object... etc.
            _Log.Info("...resource disposed!");
        }
    }

    public static class SampleFactory
    {
        public static SampleBaseLogic GetLogic(int args) 
        {
            // use args as key to get corresponding instance class.
            switch (args) 
            {
                case 1:
                    return new Logic_1();
                case 2:
                    return new Logic_2();
                default:
                    throw new ArgumentException("Factory ERROR!");
            }
        }
    }
}
