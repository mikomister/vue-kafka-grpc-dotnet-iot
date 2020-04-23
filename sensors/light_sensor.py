import os

from kafka import KafkaProducer
import json
import datetime
import RPi.GPIO as GPIO
import time

GPIO.setmode(GPIO.BCM)

gpio_pin = 17
GPIO.setup(gpio_pin, GPIO.IN)
kafka_host = os.environ.get("KAFKA_HOST", '192.168.0.103:32802')
producer = KafkaProducer(bootstrap_servers=kafka_host, value_serializer=lambda v: json.dumps(v).encode('utf-8'))

try:
    while True:
        sensor_data = GPIO.input(gpio_pin)
        producer.send('IoT', {'data': sensor_data, 'time': datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")})

        time.sleep(1.5)
except KeyboardInterrupt:
    pass
finally:
    GPIO.cleanup()
