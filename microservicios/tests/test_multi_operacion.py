import pytest
import requests
import math
from suma.suma import app as suma
from multiplicacion.multiplicacion import app as multiplicacion

@pytest.fixture
def client():
    with suma.test_client() as sum_client, multiplicacion.test_client() as mul_client:
        yield sum_client, mul_client

def test_distributiva_suma_multiplicacion(client):
    sum_client, mul_client = client
    response = sum_client.post('/api/suma', json={'n1': 2, 'n2': 3})
    assert response.status_code == 200
    response_data = float(response.data.decode('utf-8'))  # decode the response data
    response2 = mul_client.post('/api/multiplicacion', json={'n1': 2, 'n2': response_data})
    assert response2.status_code == 200
    response_data2 = float(response2.data.decode('utf-8'))  # decode the response data
    assert math.isclose(float(response_data2), 10, rel_tol=1e-9)

def test_distributiva_suma_multiplicacion_live():
    response = requests.post('http://localhost:3030/api/suma', json={'n1': 2, 'n2': 3})
    assert response.status_code == 200
    response_data = float(response.json())  # decode the response data
    response2 = requests.post('http://localhost:5050/api/multiplicacion', json={'n1': 2, 'n2': response_data})
    assert response2.status_code == 200
    response_data2 = float(response2.json())  # decode the response data
    assert math.isclose(float(response_data2), 10, rel_tol=1e-9)

def test_distributiva_multiplicacion_suma_live():
    response = requests.post('http://localhost:5050/api/multiplicacion', json={'n1': 2, 'n2': 3})
    assert response.status_code == 200
    response_data = float(response.json())  # decode the response data
    response2 = requests.post('http://localhost:3030/api/suma', json={'n1': 2, 'n2': response_data})
    assert response2.status_code == 200
    response_data2 = float(response2.json())  # decode the response data
    assert math.isclose(float(response_data2), 8, rel_tol=1e-9)