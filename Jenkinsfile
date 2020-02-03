def label = "jenkins-slave-${UUID.randomUUID().toString()}"

podTemplate(
    name: label,
    label: label,
    containers: [
        containerTemplate(name: 'docker', image: 'registry.check.com/netcore/docker:19.03.5'),
        containerTemplate(name: 'kubectl', image: 'registry.check.com/netcore/kubectl:1.17.2'),
        containerTemplate(name: 'jnlp', image: 'registry.check.com/netcore/jnlp-slave:3.40')
    ], 
    volumes: [
        hostPathVolume(mountPath: '/root/.kube', hostPath: '/root/.kube'),
        hostPathVolume(mountPath: '/var/run/docker.sock', hostPath: '/var/run/docker.sock')
    ],
    {
    node(label) {
        stage('test') {
            container('docker'){
                    echo "build test"
                }
        }
    }
})