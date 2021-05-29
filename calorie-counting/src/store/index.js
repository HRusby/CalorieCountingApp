import { createStore } from 'vuex'
import createPersistedState from 'vuex-persistedstate'

export default createStore({
  plugins: [createPersistedState()],
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
