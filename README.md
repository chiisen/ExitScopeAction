# ExitScopeAction
指定離開 Scope 執行某些動作

TimeMeasureScope 用來計算 Scope 所花的執行時間（單位 ms）
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

ExitScopeAction 可以指定執行完畢，執行某個 A
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

只要宣告個 Action 就能在離開 Scope 執行你要指定的 Action
