import json

from kafka import KafkaConsumer

consumer = KafkaConsumer('IoT', bootstrap_servers='127.0.0.1:32781',
                         value_deserializer=lambda m: json.loads(m.decode('utf-8')), group_id="iot-cg")
for msg in consumer:
    print(msg.value)
