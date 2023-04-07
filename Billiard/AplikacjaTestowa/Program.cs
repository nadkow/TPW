using Data;
using Logic;

LogicAbstractApi logic = LogicAbstractApi.CreateApi();
logic.Start(100, 100, 8);

int i=0;
while ( i<2000)
    { 
    i++;
    }