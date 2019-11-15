import Axios from 'axios'
import exampleService from '../services/ExampleService'
import clientService from '../services/ClientService'
import sellerService from '../services/SellerService'
import productService from '../services/ProductService'
import soldService from '../services/SoldService'

let apiUrl='http://localhost:49174/'

// Axios Configuration
Axios.defaults.headers.common.Accept = 'application/json'

export default {
    exampleService: new exampleService(Axios),
    clientService: new clientService(Axios,apiUrl),
    sellerService: new sellerService(Axios,apiUrl),
    productService: new productService(Axios,apiUrl),
    soldService: new soldService(Axios,apiUrl)

}