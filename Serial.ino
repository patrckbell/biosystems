/*
  DigitalReadSerial

  Reads a digital input on pin 2, prints the result to the Serial Monitor

  This example code is in the public domain.

  https://www.arduino.cc/en/Tutorial/BuiltInExamples/DigitalReadSerial
*/

// the setup routine runs once when you press reset:
void setup() {
  // initialize serial communication at 9600 bits per second:
  Serial.begin(9600);

  randomSeed(analogRead(0));
}

// the loop routine runs over and over again forever:
void loop() {
  String result = "";

  for (int i = 0; i < 4; i++) {
    int randomNumber = random(0, 2);  // Generates either 0 or 1
    result += String(randomNumber);

    if (i < 3) {
      result += ",";  // Add comma for the first 3 numbers
    }
  }

  Serial.println(result);  // Print the final string

  delay(10);  // delay in between reads for stability
}
