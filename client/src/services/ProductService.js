class ProductService {
    axios
    baseUrl

    constructor(axios,apiUrl) {
        this.axios = axios
        this.baseUrl = `${apiUrl}product`
    }


    get(id) {
        let self = this;
        return self.axios.get(`${self.baseUrl}/${id}`);
    }

    getAll() {
        let self = this;
        return self.axios.get(`${self.baseUrl}`);
    }
    getAll1() {
        let self1 = this;
        return self1.axios.get(`${self1.baseUrl}`);
    }

    add(model){
        let self = this;
        return self.axios.post(`${self.baseUrl}`,model);
    }

    update(model){
        let self = this;
        return self.axios.put(`${self.baseUrl}`,model);
    }

    remove(id){
        let self = this;
        return self.axios.delete(`${self.baseUrl}/${id}`);
    }

    sell(model){
        let self=this;
        return self.axios.post('http://localhost:49174/Sell',model);
    }

}

export default ProductService