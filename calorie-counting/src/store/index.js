import { createStore } from 'vuex'

export default createStore({
  state: {
    user: -1
  },
  mutations: {
    setUser(state, id){
      state.user = id
    },
    unsetUser(state){
      state.user = -1
    }
  },
  actions: {
  },
  modules: {
  }
})
