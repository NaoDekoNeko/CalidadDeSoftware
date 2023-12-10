import pytest
import requests
import math
from resta.resta import app as resta


@pytest.fixture
def client():
    with resta.test_client() as client:
        yield client

def test_resta_dos_negativos(client):
    response = client.post('/api/resta', json={'n1': -2, 'n2': -3})
    assert response.status_code == 200
    response_data = float(response.data.decode('utf-8')) # decode the response data
    #print(response_data)
    assert math.isclose(float(response_data), 1, rel_tol=1e-9)

def test_resta_dos_positivos(client):
    response = client.post('/api/resta', json={'n1': 2, 'n2': 3})
    assert response.status_code == 200
    response_data = int(response.data.decode('utf-8'))  # decode the response data
    #print(response_data)
    assert math.isclose(float(response_data), -1, rel_tol=1e-9)

def test_resta_live():
    response = requests.post('http://localhost:4040/api/resta', json={'n1': 2, 'n2': 3})
    assert response.status_code == 200
    response_data = response.json()
    assert math.isclose(float(response_data), -1, rel_tol=1e-9)