﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.Commons
{
    public class Table
    {
        private IWebElement element;

        public Table(IWebElement element)
        {
            this.element = element;
        }

        public string GetCellValue(string lookupColumn, string lookupValue, string returnColumn)
        {
            //if (!this.element.Text.Contains("records are available in this view.")) //No Records are available
            //{
                int lookupColumnIndex = this.GetColumnIndex(lookupColumn);
                int returnColumnIndex = this.GetColumnIndex(returnColumn);


            IReadOnlyCollection<IWebElement> rows = this.element.FindElements(By.CssSelector("tbody tr"));
                foreach (IWebElement row in rows)
                {
                    if (row.Text != "")
                    {
                        IReadOnlyCollection<IWebElement> cells = row.FindElements(By.TagName("td"));
                        if ((cells.Count >= lookupColumnIndex + 1) && (cells.ElementAt(lookupColumnIndex).Text == lookupValue))
                        {
                            return cells.ElementAt(returnColumnIndex).Text;
                        }
                    }
                }

            throw new Exception(String.Format("Unable to find table row {0} with value {1}", lookupColumn, lookupValue));
        }

        public bool ClickCellValue(string lookupColumn, string lookupValue, string returnColumn, IWebDriver d)
        {
            //if (!this.element.Text.Contains("records are available in this view.")) //No Records are available
            //{
            int lookupColumnIndex = this.GetColumnIndex(lookupColumn);
            int returnColumnIndex = this.GetColumnIndex(returnColumn);




            IReadOnlyCollection<IWebElement> rows = this.element.FindElements(By.CssSelector("tbody tr"));
            foreach (IWebElement row in rows)
            {
                if (row.Text != "")
                {
                    IReadOnlyCollection<IWebElement> cells = row.FindElements(By.CssSelector("td"));



                    if ((cells.Count >= lookupColumnIndex + 1) && (cells.ElementAt(lookupColumnIndex).Text == lookupValue))
                    {
                        IWebElement cell = cells.ElementAt(returnColumnIndex);
                        Actions action = new Actions(d);
                        action.MoveToElement(cell, cell.Size.Width / 2, cell.Size.Height / 2).ClickAndHold().Build().Perform();
                        Thread.Sleep(500);
                        action.MoveToElement(cell, cell.Size.Width / 2, cell.Size.Height / 2).Release().Build().Perform();
                        return true;
                    }
                }
            }
            
            throw new Exception(String.Format("Unable to find table row {0} with value {1}", lookupColumn, lookupValue));
        }


        private int GetColumnIndex(string lookupColumn)
        {   
            IReadOnlyCollection<IWebElement> headerCells = this.element.FindElements(By.CssSelector("thead tr th"));
            for (int i = 0; i < headerCells.Count; i++)
            {
                
                string text = headerCells.ElementAt(i).Text;

                if (text.Equals(lookupColumn))
                {
                    return i;
                }
            }
            throw new Exception("Unable to find column " + lookupColumn);
        }

        public int GetRowCount()
        {
            IReadOnlyCollection<IWebElement> rows = this.element.FindElements(By.CssSelector("tbody tr"));
            return rows.Count;
        }

        public bool GetNoRecordsInTable()
        {
            //get rows
            IReadOnlyCollection<IWebElement> tableRows = this.element.FindElements(By.CssSelector("tbody tr td"));
            if (tableRows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public int GetColumnHeaderIndex(string ColumnName)
        {
            IReadOnlyCollection<IWebElement> headers = this.element.FindElements(By.CssSelector("tbody tr th"));
            int headerCount = headers.Count;
            int currentCount = 0;

            foreach (IWebElement header in headers)
            {
                currentCount += 1;
                if (header.GetAttribute("displaylabel") == ColumnName)
                {
                    return currentCount;
                }
            }
            return 0; // If specified column not found return 0
        }

        

        public void selectFirstTableRow()
        {
            IReadOnlyCollection<IWebElement> tableRows = this.element.FindElements(By.CssSelector("tbody tr td"));
            tableRows.First().Click();
        }
    }
}