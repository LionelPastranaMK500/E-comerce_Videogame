!pip install bcrypt
import bcrypt
hash = bcrypt.hashpw(b"password1", bcrypt.gensalt(11))
print(hash.decode())


# se usa en google colab para hacer el hashado manual