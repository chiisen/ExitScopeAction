# ExitScopeAction
指定離開 Scope 執行某些動作

## TimeMeasureScope 用來計算 Scope 所花的執行時間（單位 ms）
``` c#  
void exitCall_(long t, string x)
{
    MSTestLog.WriteLine($"{x} 執行 {t} ms");
}

using (var tms = new TimeMeasureScope(exitCall_, "for loop"))
{
    Thread.Sleep(2000);
}
```  
## Version >= 1.0.8 調整了建構式參數傳入的順序  
``` c#  
void exitTimeMeasure_(long t, string x)
{
    MSTestLog.WriteLine($"{x} 執行 {t} ms");
}

using (var tms = new TimeMeasureScope("for loop", exitTimeMeasure_))
{
    for (int i = 0; i < 10; ++i)
    {
        Thread.Sleep(200);
    }
}
```
## Version >= 1.0.8 提供特化類別，減少初始化的程式碼輸入
``` c# 
public class TMS : TimeMeasureScope
{
    // 建立特化類別
    public TMS(string title, Action<long, string> action = null) : base
        (   title,
            (t, x) => 
            {
                MSTestLog.WriteLine($"{x} 執行 {t} ms");
            })
    {
    }
}
```  
使用特化類別
``` c# 
using (var tms = new TMS("for loop 2"))
{
    for (int i = 0; i < 10; ++i)
    {
        Thread.Sleep(200);
    }
}
```  

## ExitScopeAction 可以指定執行完畢，執行某個 Action
``` c#  
void exitAction_()
{
    MSTestLog.WriteLine("執行完畢！");
}

using (var tms = new ExitScopeAction(exitAction_, "exit action"))
{
    Thread.Sleep(2000);
}
```
## Version >= 1.0.8 調整了建構式參數傳入的順序
``` c#  
void exitCallback_()
{
    MSTestLog.WriteLine("離開 Scope 執行完畢！");
}

using (var tms = new ExitScopeAction("離開 Scope 執行", exitCallback_))
{
    Thread.Sleep(2000);
}
```
## Version >= 1.0.8 提供特化類別，減少初始化的程式碼輸入
``` c#
public class ESA : ExitScopeAction
{
    public ESA(Action action, string title) : base
        (title,
        () =>
        {
            MSTestLog.WriteLine("離開 Scope 2 執行完畢！");
        })
    {
    }
}
```
使用特化類別
``` c#
using (var tms = new ESA(null, "離開 Scope 2 執行"))
{
    Thread.Sleep(2000);
}
```
只要宣告個 Action 就能在離開 Scope 執行你要指定的 Action
