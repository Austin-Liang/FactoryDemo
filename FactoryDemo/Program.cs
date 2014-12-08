﻿/*
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
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDemo
{
    class Program
    {
        private static readonly ILog _mLog = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            _mLog.Info("========== [Process Start] ==========");

            try
            {
                {   // loop through logics from sample factory.
                    for (int i = 1; i <= 2; i++)
                    {
                        // get logic from factory.
                        SampleBaseLogic sbl = SampleFactory.GetLogic(i);
                        _mLog.InfoFormat("factory get : {0}", sbl.GetType().Name);

                        // proceed custom business logic.
                        sbl.Run();
                        _mLog.InfoFormat("{0} executed successfully!", sbl.GetType().Name);

                        // dispose if needed.
                        sbl.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                _mLog.Error((ex.InnerException ?? ex).Message);
                _mLog.Error(ex.StackTrace);
            }
            finally 
            {
                _mLog.Info("========== [Process End] ==========");
            }

        }
    }
}
