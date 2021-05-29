import { createStore } from 'vuex'

export default createStore({
  state: {
    user: -1
  },
  mutations: {
    setUser(id){
      this.state.user = id
    }
  },
  actions: {
  },
  modules: {
  }
})
