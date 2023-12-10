import pytest
import math
import requests
from division.division import app as division

@pytest.fixture
def client():
    with division.test_client() as client:
        yield client
def test_division_un_positivo_un_negativo(client):
    response = client.post('/api/division', json={'n1': -2, 'n2': 3})
    assert response.status_code == 200
    response_data = response.data.decode('utf-8')  # decode the response data
    print(response_data)    
    assert math.isclose(float(response_data), -0.6666666666666666, rel_tol=1e-9)

def test_division_con_cero(client):
    response = client.post('/api/division', json={'n1': 2, 'n2': 0})
    assert response.status_code == 200
    response_data = response.data.decode('utf-8')  # decode the response data
    print(response_data)    
    assert response_data == 'Error'

def test_division_dos_positivos(client):
    response = client.post('/api/division', json={'n1': 2, 'n2': 3})
    assert response.status_code == 200
    response_data = response.data.decode('utf-8')  # decode the response data
    print(response_data)
    assert math.isclose(float(response_data), 0.6666666666666666, rel_tol=1e-9)

def test_division_dos_negativos(client):
    response = client.post('/api/division', json={'n1': -2, 'n2': -3})
    assert response.status_code == 200
    response_data = response.data.decode('utf-8')  # decode the response data
    print(response_data)
    assert math.isclose(float(response_data), 0.6666666666666666, rel_tol=1e-9)

def test_division_live():
    response = requests.post('http://localhost:6060/api/division', json={'n1': 2, 'n2': 3})
    assert response.status_code == 200
    response_data = response.json()
    assert math.isclose(float(response_data), 0.6666666666666666, rel_tol=1e-9)  # assuming the response is {'result': 5}