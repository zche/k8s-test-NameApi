podTemplate(
    name: 'test-jnlp',
    label: 'test-jnlp',
    containers: [
        containerTemplate(name: 'jnlp', image: 'registry.check.com/netcore/jnlp-slave:3.40', command: 'cat', ttyEnabled: true)
    ], 
    volumes: [
        hostPathVolume(mountPath: '/root/.kube', hostPath: '/root/.kube'),
        hostPathVolume(mountPath: '/var/run/docker.sock', hostPath: '/var/run/docker.sock')
    ],
    {
    node('test-jnlp') {
        stage('test') {
            container('jnlp'){
                    echo "build test"
                }
        }
    }
})