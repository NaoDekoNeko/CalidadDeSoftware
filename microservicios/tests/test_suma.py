import pytest
import math
import requests
from suma.suma import app as suma

@pytest.fixture
def client():
    with suma.test_client() as client:
        yield client

def test_suma_dos_positivos(client):
    response = client.post('/api/suma', json={'n1': 2, 'n2': 3})
    assert response.status_code == 200
    response_data = response.data.decode('utf-8')  # decode the response data
    print(response_data)
    assert math.isclose(float(response_data), 5, rel_tol=1e-9)

def test_suma_dos_negativos(client):
    response = client.post('/api/suma', json={'n1': -2, 'n2': -3})
    assert response.status_code == 200
    response_data = response.data.decode('utf-8')  # decode the response data
    print(response_data)
    assert math.isclose(float(response_data), -5, rel_tol=1e-9)

def test_suma_un_positivo_un_negativo(client):
    response = client.post('/api/suma', json={'n1': -2, 'n2': 3})
    assert response.status_code == 200
    response_data = response.data.decode('utf-8')  # decode the response data
    print(response_data)    
    assert math.isclose(float(response_data), 1, rel_tol=1e-9)

def test_suma_live():
    response = requests.post('http://localhost:3030/api/suma', json={'n1': 2, 'n2': 3})
    assert response.status_code == 200
    response_data = response.json()
    assert math.isclose(float(response_data), 5, rel_tol=1e-9)  # assuming the response is {'result': 5}