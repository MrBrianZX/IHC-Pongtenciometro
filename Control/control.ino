
const int potenciometro = A0;    // seleccionar la entrada para el sensor
const int button = A1; 
const int left = A2;
const int dead = A3;
const int right = A4;
const int buttonLED = A5;
int sensorValue;       // variable que almacena el valor raw (0 a 1023)

void setup()
{
   Serial.begin(9600);
   pinMode(left, OUTPUT);
   pinMode(right, OUTPUT);
   pinMode(dead, OUTPUT);
   pinMode(button, INPUT);
}
void loop() 
{
  sensorValue = analogRead(potenciometro);   // realizar la lectura
  //mandar mensaje a puerto serie en función del valor leido
  digitalWrite(right, LOW);
  digitalWrite(left, LOW);
  digitalWrite(dead, LOW);
  digitalWrite(buttonLED,LOW);
  if(sensorValue > 582){
         digitalWrite(right, HIGH);
         Serial.println("R");
  }
  else if (sensorValue < 472){
     digitalWrite(left, HIGH);
     Serial.println("L");
  }
  else{
    digitalWrite(dead, HIGH);
    Serial.println("D");
  }
    
  if(digitalRead(button)){
    digitalWrite(buttonLED, HIGH);
    Serial.println("B");
  }
  delay(16);
}
