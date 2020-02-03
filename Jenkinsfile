def label = "slave-check"

podTemplate(label: label, containers: [
  containerTemplate(name: 'docker', image: 'registry.check.com/netcore/docker:19.03.5'),
  containerTemplate(name: 'kubectl', image: 'registry.check.com/netcore/kubectl:1.17.2'),
  containerTemplate(name: 'jnlp', image: 'registry.check.com/netcore/jnlp-slave:3.40')
], volumes: [
  hostPathVolume(mountPath: 'root/.kube', hostPath: '/root/.kube'),
  hostPathVolume(mountPath: '/var/run/docker.sock', hostPath: '/var/run/docker.sock')
]) {
  node(label) {

    stage('test') {
      echo "test"
    }
    stage('build') {
      container('docker') {
        echo "build Docker "
      }
    }
    stage('run Kubectl') {
      container('kubectl') {
        echo "check K8S cluster pods"
        sh "kubectl get pods"
      }
    }
  }
}