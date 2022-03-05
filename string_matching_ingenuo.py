import sys

if(len(sys.argv) < 3):
    print("Debe pasar 2 argumentos: <texto> <patron>")
    exit()
else:
    # se leen el texto y el patron a buscar desde argumentos de consola
    texto = sys.argv[1]
    patron = sys.argv[2]

    if(len(texto) < len(patron)):
        print("El patron no puede ser más largo que el texto mismo")
        exit()
    
    encontrado = []

    for i in range(len(texto) - len(patron) + 1):
        substring = texto[i:i+len(patron)]
        print("Matching {} en {}".format(patron,substring))
        if(patron == substring):
            encontrado.append(i)
    
    print(encontrado)