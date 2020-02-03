def label = "jenkins-slave-${UUID.randomUUID().toString()}"

podTemplate(
    name: label,
    label: label,
    containers: [
        containerTemplate(name: 'jnlp', image: 'registry.check.com/netcore/jnlp-slave:3.40')
    ], 
    volumes: [
        hostPathVolume(mountPath: '/root/.kube', hostPath: '/root/.kube'),
        hostPathVolume(mountPath: '/var/run/docker.sock', hostPath: '/var/run/docker.sock')
    ],
    {
    node(label) {
        stage('test') {
            container('jnlp'){
                    echo "build test"
                }
        }
    }
})