using Model;

ModelAbstractApi model = ModelAbstractApi.CreateApi();
model.Start(8);

int i=0;
while ( i<2000)
    { 
    i++;
    }

model.Stop();