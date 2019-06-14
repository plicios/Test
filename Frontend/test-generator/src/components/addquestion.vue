<template>
<div>
    <h2>Question statement</h2>

<b-container fluid>
  <b-row class="mt-2">
    <b-col sm="3">
    </b-col>
    <b-col sm="8">
      <b-form-textarea id="textarea" v-model="question" placeholder="Write the question statement here..." rows="1" max-rows="6" ></b-form-textarea>
    </b-col>
    <b-col sm="3">
    </b-col>
  </b-row>
</b-container>


<br>
    <!-- <textarea v-model="question" placeholder="Write the question statement here..."></textarea> -->
    <h2>Answers</h2>

    <div v-for="n in index" :key="n.id">
        
        
        <b-container fluid>
            <b-row class="mt-2">
                <b-col sm="3">
                    
                </b-col>
                <b-col sm="8">
                    <b-row>
                        <b-col sm="1">
                            <b-form-radio type="radio" :id="n" :value="n" v-model="picked"></b-form-radio>
                        </b-col>
                        <b-col sm=10>
                            <b-form-textarea v-model="alternatives[n-1]" placeholder="Write the answer here..." rows="1" max-rows="6" ></b-form-textarea>
                        </b-col>
                        <b-col sm="1">
                            <b-button pill variant="danger" v-on:click="minus(n)">-</b-button>
                        </b-col>
                    </b-row>
                    
                    
                </b-col>
                <b-col sm="3">
                </b-col>
            </b-row>
        </b-container>

        <!-- <textarea v-model="alternatives[n-1]" placeholder="Write the answer here..."></textarea> -->
        
    </div>
    <br>

    <b-button pill variant="primary" v-on:click="plus">+</b-button>
        

    <br>
    <br>
    

    <b-button variant="success" v-on:click="save">Save</b-button>
    
    

</div>
</template>

<script>
    export default {
        name: 'AddQuestions',
        inputs:
        {
            name: ''
        },
        components: {
            
        },
        data() {
            return {
                message: '',
                alternatives: ['',''],
                index: 2,
                picked: 1
            }
        },
        methods:
        {
            plus: function ()
            {
                this.index += 1;
                this.alternatives.push('')
            },
            minus: function (n)
            {
                if(this.index > 2)
                {
                    this.alternatives.splice(n-1,1);
                    if(this.picked == n)
                    {
                        this.picked = 1;
                    }

                    this.index -= 1;
                }
            },
            save: function ()
            {
                alert("save")
            },
            
        }
    }
</script>