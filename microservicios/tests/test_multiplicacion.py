import pytest
import math
import requests
from multiplicacion.multiplicacion import app as multiplicacion

@pytest.fixture
def client():
    with multiplicacion.test_client() as client:
        yield client

def test_multiplicacion_dos_positivos(client):
    response = client.post('/api/multiplicacion', json={'n1': 2, 'n2': 3})
    assert response.status_code == 200
    response_data = response.data.decode('utf-8')  # decode the response data
    #print(response_data)
    assert math.isclose(float(response_data), 6, rel_tol=1e-9)

def test_multiplicacion_dos_negativos(client):
    response = client.post('/api/multiplicacion', json={'n1': -2, 'n2': -3})
    assert response.status_code == 200
    response_data = response.data.decode('utf-8')  # decode the response data
    #print(response_data)
    assert math.isclose(float(response_data), 6, rel_tol=1e-9)

def test_multiplicacion_un_positivo_un_negativo(client):
    response = client.post('/api/multiplicacion', json={'n1': -2, 'n2': 3})
    assert response.status_code == 200
    response_data = response.data.decode('utf-8')  # decode the response data
    #print(response_data)    
    assert math.isclose(float(response_data), -6, rel_tol=1e-9)

def test_multiplicacion_live():
    response = requests.post('http://localhost:5050/api/multiplicacion', json={'n1': 2, 'n2': 3})
    assert response.status_code == 200
    response_data = response.json()
    assert math.isclose(float(response_data), 6, rel_tol=1e-9)  # assuming the response is {'result': 5}