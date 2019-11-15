<template>
<div>
<center>
<h2>{{pageTitle}}</h2>
</center>
  <el-form v-loading="loading" :model="form" :rules="rules" ref="ruleForm" >
  <el-form-item label="Nombre" prop="name">
  <el-input v-model="form.name" ></el-input>
  </el-form-item>

  <el-form-item label="Apellido" prop="lastName">
  <el-input v-model="form.lastName" ></el-input>
  </el-form-item>

<el-form-item label="Cedula" prop="idNumber">
  <el-input v-model="form.idNumber" ></el-input>
  </el-form-item>

<el-form-item label="Datos de la Compañia" prop="bio">
  <el-input type="textarea" v-model="form.bio" ></el-input>
  </el-form-item>
  <el-form-item>
  <el-button @click="save" type="primary">Guardar vendedor</el-button>
</el-form-item>
</el-form>
  
  
  </el-form>
</div>
</template>

<script>
export default {
  name: "ClientCreateOrUpdate",
  data() {
    return {
      loading: false,
      form: {
        clientId:0,
        name: null,
        lastName: null,
        idNumber: null,
        bio: null
      },
      rules:{
        name:[
        {required:true, message:'Debe ingresar un nombre'},
        {min:3,message:'Su nombre debe contener al menos 3 caracteres'}
        ],
        lastName:[
        {required:true, message:'Debe ingresar su apellido'}
        ],
        idNumber:[
        {required:true, message:'Su cedula es requerida'}
        ],
        bio:[
        {required:true, message:'Su commpañia es requerida'}
        ],
      }
    };
  },
  computed:{
    pageTitle(){
     return this.form.clientId === 0 ? "Nuevo Vendedor":this.form.name;
    }
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
      self.$store.state.services.clientService
          .get(id)
          .then(r=>{
            self.loading=false;
            self.form.clientId=r.data.clientId;
            self.form.name=r.data.name;
            self.form.lastName=r.data.lastName;
            self.form.idNumber=r.data.idNumber;
            self.form.bio=r.data.bio;
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

          if(self.form.clientId>0){
            self.$store.state.services.clientService
          .update(self.form)
          .then(r=>{
            self.loading=false;
            self.$router.push('/clients');
          })
          .catch(r=>{
            self.$message({
              message:"Ocurrio un error inesperado",
              type:"error"
            });
          });
          }else{
          self.$store.state.services.clientService
          .add(self.form)
          .then(r=>{
            self.loading=false;
            self.$router.push('/clients');
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