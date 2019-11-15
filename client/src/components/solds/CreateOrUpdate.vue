<template>
<div>
<center>
<h2> Total Productos</h2>
</center>
<el-form :model="form">
 <el-table v-loading="loading" :data="data" :model="table">
 <el-table-column prop="name" label="Nombre" width="200" sortable>
 <template slot-scope="scope">
 {{scope.row.lastName}}, {{scope.row.name}}
 </template>
 </el-table-column>
 <el-table-column prop="price" label="Precio C/U" width="100"sortable></el-table-column>
 <el-table-column prop="type" label="Derivación" width="100" sortable></el-table-column>
<el-table-column prop="amount" label="Cantidad" width="200" sortable></el-table-column>
 </el-table>
 <el-button type="danger" @click="sell()"> Vender</el-button>
  <selector @seleccionar="seleccionado"></selector>
 <el-input v-model="total"></el-input>
</el-form>
</div>
</template>

<script>
import selector from '../solds/Index'
export default {
components:{selector},
  name: "ProductIndex",
  data() {
    return {
      loading:false,
      total:0,
      data:[],
      form:{
        product:[],
        Sold:{
        SoldId:0,
        ClientId:1,
        SellerId:1,
        Price:0,
        amount:7,
        Date:'2018/8/17'
        },
      }
    };
  },

  created() {

    let self = this;
    self.getAll();


  },
  methods: {
    getAll(){
      let self=this;
      self.loading=true;

      self.$store.state.services.productService
      .getAll()
      .then(r =>{
        self.loading=false;
        self.form.product=r.data,
        self.data=r.data;
        for(let i=0; i<=this.data.length;i++){
          this.form.Sold.Price=this.data[i].price*this.data[i].amount
          this.total+=this.form.Sold.Price
        }
      })
      .catch(r =>{
        
      });

      },
      seleccionado(){
        alert("Funciona");
      },
      sell(){
        let self = this;
        self.$store.state.services.productService
        .sell(this.form)
        .then(p=>{
          self.$message({
          message:"Venta realizada",
          type:"success"
        });
        })
      }

  }
};
</script>
