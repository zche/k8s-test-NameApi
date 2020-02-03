def label = "jenkins-slave-${UUID.randomUUID().toString()}"

podTemplate(
    name: label,
    label: label,
    containers: [
        containerTemplate(name: 'docker', image: 'registry.check.com/netcore/docker:19.03.5')
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