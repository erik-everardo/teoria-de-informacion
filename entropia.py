import sys
import json
import math

def leer_datos():
    print("Ingrese las probabilidades, separadas por una coma.")
    entrada = input().split(',')
    for i in entrada:
        probabilidades.append(float(i))

entropia = 0
probabilidades = []

# se revisa si hay un argumento en la consola
# se espera recibir la ruta del archivo json
if(len(sys.argv) > 1):
    # Se intenta leer el json
    try:
        archivo = open(sys.argv[1],"r")
        probabilidades = json.loads(archivo.read())
        archivo.close()
    except FileNotFoundError:
        print("No se ha encontrado el archivo {}".format(sys.argv[1]))
        leer_datos()
else:
    leer_datos()

print("Tipo de proceso")
print("1. Cuantificable")
print("2. Transmisión de datos binaria")
print("3. Transición entre estados")
print("*******************************")
print("0. Salir")

tipo_de_proceso = input()

if (tipo_de_proceso == "1"):
    for i in probabilidades:
        entropia_evento = i * math.log10(i)
        print("Probabilidad {}: {}".format(i,entropia_evento * -1))
        entropia = entropia + entropia_evento
elif(tipo_de_proceso == "2"):
    for i in probabilidades:
        entropia_evento = i * math.log(i,2)
        print("Probabilidad {}: {}".format(i,entropia_evento * -1))
        entropia = entropia + entropia_evento
elif(tipo_de_proceso == "3"):
    for i in probabilidades:
        entropia_evento = i * math.log(i,math.e)
        print("Probabilidad {}: {}".format(i,entropia_evento * -1))
        entropia = entropia + entropia_evento
elif(tipo_de_proceso == "0"):
    exit()
else:
    print("Opcion incorrecta")


entropia = entropia * -1
print(entropia)