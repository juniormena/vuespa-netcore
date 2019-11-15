<template>
<div>
<center>
<h2>{{pageTitle}}</h2>
</center>
  <el-form v-loading="loading" :model="form" :rules="rules" ref="ruleForm" >
  <el-form-item label="Nombre" prop="name">
  <el-input v-model="form.name" ></el-input>
  </el-form-item>

  <el-form-item label="Precio por unidad" prop="price">
  <el-input v-model="form.price" ></el-input>
  </el-form-item>

<el-form-item label="Derivación" prop="type">
  <el-input v-model="form.type" ></el-input>
  </el-form-item>

<el-form-item label="Cantidad" prop="amount">
  <el-input  v-model="form.amount" ></el-input>
  </el-form-item>
  <el-form-item>
  <el-button @click="save" type="primary">Guardar Producto</el-button>
</el-form-item>
</el-form>
  
  
  </el-form>
</div>
</template>

<script>
export default {
  name: "ProductCreateOrUpdate",
  data() {
    return {
      loading: false,
      form: {
        productId:0,
        name: null,
        price:null,
        type: null,
        amount: null
      },
      rules:{
        name:[
        {required:true, message:'Debe ingresar un nombre'},
        {min:3,message:'Su nombre debe contener al menos 3 caracteres'}
        ],
        price:[
        {required:true, message:'Debe ingresar un precio'}
        ],
        type:[
        {required:true, message:'Debe ingresar una derivación del producto(tipo) '}
        ],
        amount:[
        {required:true, message:'Debe ingresar una cantidad'}
        ],
      }
    };
  },
  computed:{
    pageTitle(){
     return this.form.productId === 0 ? "Nuevo Producto":this.form.name;
    },
  },
  created() {
    let self = this;
    self.get(self.$route.params.id);
  },
  methods: {
    get(id){
      if(id==undefined)return;

      let self=this;
      self.loading=true;
      self.$store.state.services.productService
          .get(id)
          .then(r=>{
            self.loading=false;
            self.form.productId=r.data.productId;
            self.form.name=r.data.name;
            self.form.price=r.data.price;
            self.form.type=r.data.type;
            self.form.amount=r.data.amount;
          })
          .catch(r=>{
            self.$message({
              message:"Ocurrio un error inesperado",
              type:"error"
            });
          });
    },
    save(){
      let self =this;
      self.$refs["ruleForm" ].validate((valid)=>{
        if(valid){
          self.loading=true;

          if(self.form.productId>0){
            self.$store.state.services.productService
          .update(self.form)
          .then(r=>{
            self.loading=false;
            self.$router.push('/products');
          })
          .catch(r=>{
            self.$message({
              message:"Ocurrio un error inesperado",
              type:"error"
            });
          });
          }else{
          self.$store.state.services.productService
          .add(self.form)
          .then(r=>{
            self.loading=false;
            self.$router.push('/products');
          })
          .catch(r=>{
            self.$message({
              message:"Ocurrio un error inesperado",
              type:"error"
            });
          });
          }
        }
      });
    }
  }
};
</script>